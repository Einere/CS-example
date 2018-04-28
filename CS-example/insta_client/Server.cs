﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using insta_packet;

namespace insta_client
{
    public partial class Server : Form
    {
        private NetworkStream stream = null;
        private TcpListener listener = null;
        private StreamReader f_reader = null;
        private StreamWriter f_writer = null;
        private bool is_connected = false;
        private Thread thread = null;
        private delegate void Delegator();
        private Delegator delegator;
        private static int size = 1024 * 10;
        private byte[] r_buffer = new byte[size];
        private byte[] w_buffer = new byte[size];
        private Flag success = null;
        private Member member = null;
        private Post post = null;

        public Server()
        {
            InitializeComponent();
            tb_ip.Text = get_IP();
        }

        private string get_IP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string IP = string.Empty;
            for(int i = 0; i < host.AddressList.Length; i++)
            {
                //select IPv4, not IPv6
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork) IP = host.AddressList[i].ToString();
            }
            return IP;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void send()
        {
            if (this.stream != null)
            {
                //write w_buffer's data at stream, and flush
                this.stream.Write(this.w_buffer, 0, this.w_buffer.Length);
                this.stream.Flush();

                //init w_buffer
                for (int i = 0; i < size; i++) this.w_buffer[i] = 0;
            }
            else
            {
                MessageBox.Show("this.stream is null");
            }
        }

        private void read_load_m_file()
        {
            try
            {
                this.f_reader = new StreamReader("member.txt");
            }
            catch
            {
                MessageBox.Show("fail to open member.txt at read_load_m_file()");
            }

            //set offset to head
            if (this.f_reader.Peek() < 0) this.f_reader.BaseStream.Seek(0, SeekOrigin.Begin);

            //get data from text file, set item and add at list view
            int i = 1;
            while (f_reader.Peek() >= 0)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                foreach(string str in f_reader.ReadLine().Split(new char[] { ',' })){
                    item.SubItems.Add(str);
                }
                
                lv_member.Items.Add(item);
                i++;
            }
            this.f_reader.Close();
            this.f_reader = null;
        }

        private void sign_up(Flag result)
        {
            //check already exist member id
            foreach (ListViewItem item in lv_member.Items)
            {
                //if already exist member id
                if (item.SubItems[1].Text == this.member.ID)
                {
                    result.success = false;
                    break;
                }
            }

            //if not already exist id, insert to lv_member
            if (result.success == true)
            {
                //add data to lv_member
                ListViewItem item = new ListViewItem((lv_member.Items.Count + 1).ToString());
                item.SubItems.Add(this.member.ID);
                item.SubItems.Add(this.member.password);
                lv_member.Items.Add(item);

                //log to tb_log
                tb_log.AppendText(String.Format("{0} is registered...\n", this.member.ID));

                //save received packet data to member.txt
                if (this.f_writer == null) {
                    this.f_writer = new StreamWriter("member.txt", true);
                }
                f_writer.WriteLine(string.Format(this.member.ID + "," + this.member.password + "," + Convert.ToBase64String(this.member.profile_pic) + "," + this.member.comment));
                f_writer.Flush();
                f_writer.Close();
                f_writer = null;
            }

            //send result packet to client
            Packet.Serialize(result).CopyTo(this.w_buffer, 0);
            this.send();

            MessageBox.Show("member account list update and send result packet complete");
        }

        private void log_in(Flag result)
        {
            result.success = false;
            
            //for all element in lv_member.items
            foreach(ListViewItem item in lv_member.Items)
            {
                //if match id & password
                if(item.SubItems[1].Text == this.member.ID && item.SubItems[2].Text == this.member.password)
                {
                    result.success = true;

                    //log to tb_log
                    tb_log.AppendText(String.Format("{0} is log in...\n", this.member.ID));
                }
            }

            //send result packet to client
            Packet.Serialize(result).CopyTo(this.w_buffer, 0);
            this.send();

            MessageBox.Show("log in process and send result packet complete");
        }

        private void send_member_list()
        {
            Member mem = new Member();
            mem.Type = (int)PacketType.member;
            mem.purpose = 3;
            
            foreach(ListViewItem item in lv_member.Items)
            {
                mem.ID = item.SubItems[1].Text;

                //serialize packet
                Packet.Serialize(mem).CopyTo(this.w_buffer, 0);
                this.send();

                //MessageBox.Show(string.Format("send id '{0}'", mem.ID));
            }
        }

        private void send_member_info()
        {
            //save request member id
            string login_id = this.member.ID;

            Member mem = new Member();
            mem.Type = (int)PacketType.member;
            mem.purpose = 4;

            this.post = new Post();
            post.Type = (int)PacketType.post;

            //find request member tuple in member.txt for profile_pic, comment
            try
            {
                this.f_reader = new StreamReader("member.txt");
            }
            catch
            {
                MessageBox.Show("fail to open member.txt at send_member_info()");
            }

            //set offset to head
            if (this.f_reader.Peek() < 0) this.f_reader.BaseStream.Seek(0, SeekOrigin.Begin);

            //get data from member.txt
            while (f_reader.Peek() >= 0)
            {
                string[] str_arr = this.f_reader.ReadLine().Split(new char[] { ',' });
                if (str_arr[0] == login_id)
                {
                    //if same id in tuple
                    mem.profile_pic = Convert.FromBase64String(str_arr[2]);
                    mem.comment = str_arr[3];
                    break;
                }
            }
            this.f_reader.Close();
            this.f_reader = null;

            //find request member tuple in post.txt for post_count, picutre, comment, time
            try
            {
                this.f_reader = new StreamReader("post.txt");
            }
            catch
            {
                MessageBox.Show("fail to open post.txt at send_member_info()");
            }

            //set offset to head
            if (this.f_reader.Peek() < 0) this.f_reader.BaseStream.Seek(0, SeekOrigin.Begin);

            //get data from post.txt
            int count = 0;
            while (f_reader.Peek() >= 0)
            {
                string[] str_arr = this.f_reader.ReadLine().Split(new char[] { ',' });
                //if same id in tuple, count++
                if (str_arr[0] == login_id)
                {
                    //set post packet to send client
                    this.post.picture = Convert.FromBase64String(str_arr[1]);
                    this.post.comment = str_arr[2];
                    this.post.time = DateTime.Parse(str_arr[3]);

                    //send post packet to client
                    Packet.Serialize(this.post).CopyTo(w_buffer, 0);
                    this.send();

                    count++;
                }
            }
            mem.post_count = count;

            this.f_reader.Close();
            this.f_reader = null;

            //send member packet to client
            Packet.Serialize(mem).CopyTo(w_buffer, 0);
            this.send();
            MessageBox.Show("send info complete");
        }

        private void receive()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                //if not complete ip & port textbox
                if (tb_ip.TextLength == 0 || tb_port.TextLength == 0)
                {
                    MessageBox.Show("please type IP and port");
                    return;
                }

                //check file is exist, create or return
                if (!File.Exists("member.txt"))
                {
                    MessageBox.Show("file isn't exist");
                    FileStream f_stream = File.Create("member.txt"); // need to write encoding argument
                    f_stream.Close();
                    return;
                }

                //check file is exist, create or return
                if (!File.Exists("post.txt"))
                {
                    MessageBox.Show("file isn't exist");
                    FileStream f_stream = File.Create("post.txt"); // need to write encoding argument
                    f_stream.Close();
                    return;
                }

                //read and load member file
                read_load_m_file();

                //change start button
                bt_start.ForeColor = Color.OrangeRed;
                bt_start.Text = "stop";

                MessageBox.Show("member account list load complete");

                //check client is connected or not
                if (!this.is_connected)
                {
                    //waiting client
                    if (this.listener == null) this.listener = new TcpListener(Int32.Parse(tb_port.Text));
                    this.listener.Start();

                    //if not connected
                    tb_log.AppendText("waiting for client...\n");
                    
                    //get client socket
                    TcpClient client = this.listener.AcceptTcpClient();

                    //if connected
                    if (client.Connected)
                    {
                        this.is_connected = true;

                        tb_log.AppendText("client connected...!\n");

                        //get client stream
                        this.stream = client.GetStream();

                        //read data from client until disconnection. 스레드로 만들어야 될 것 같다 (신호 수신용)
                        while (this.is_connected)
                        {
                            int n_read = 0;

                            try
                            {
                                //read data from stream to r_buffer
                                n_read = 0;
                                n_read = this.stream.Read(r_buffer, 0, size);
                            }
                            catch
                            {
                                this.is_connected = false;
                                this.stream = null;
                            }

                            //if r_buffer is null
                            if (this.r_buffer == null)
                            {
                                MessageBox.Show("r_buffer is null");
                                return;
                            }

                            //need to deal when disconnecting signal recieved before deserialize
                            if (n_read == 0)
                            {
                                this.is_connected = false;
                                continue;
                            }

                            Packet packet = (Packet)Packet.Deserialize(this.r_buffer);

                            switch ((int)packet.Type)
                            {
                                case (int)PacketType.flag:
                                    {
                                        this.success = (Flag)Packet.Deserialize(this.r_buffer);

                                        string msg = String.Format("flag packet : success = {0}, ", this.success.success.ToString());
                                        MessageBox.Show(msg);

                                        break;
                                    }
                                case (int)PacketType.member:
                                    {
                                        this.member = (Member)Packet.Deserialize(this.r_buffer);

                                        //for response to client
                                        Flag result = new Flag();
                                        result.Type = (int)PacketType.flag;
                                        result.success = true;

                                        switch (this.member.purpose)
                                        {
                                            //if packet for sign up
                                            case 1:
                                                sign_up(result);
                                                break;
                                            //if packet for log in
                                            case 2:
                                                log_in(result);
                                                break;
                                            //if packet for member list request
                                            case 3:
                                                send_member_list();
                                                break;
                                            //if packet for member info request
                                            case 4:
                                                send_member_info();
                                                break;
                                        }

                                        break;
                                    }
                                case (int)PacketType.post:
                                    {
                                        this.post = (Post)Packet.Deserialize(this.r_buffer);

                                        //return result to client
                                        this.success = new Flag();
                                        this.success.Type = (int)PacketType.flag;

                                        try
                                        {
                                            //save received post data
                                            if (this.f_writer == null) f_writer = new StreamWriter("post.txt", true);
                                            string str = string.Format(this.post.ID + "," + Convert.ToBase64String(this.post.picture) + "," + this.post.comment + "," + this.post.time);
                                            f_writer.WriteLine(str);
                                            f_writer.Flush();
                                            f_writer.Close();
                                            f_writer = null;

                                            this.success.success = true;
                                        }
                                        catch(Exception e)
                                        {
                                            MessageBox.Show(e.ToString());
                                            //MessageBox.Show(Encoding.UTF8.GetString(this.post.picture));
                                            this.success.success = false;
                                            
                                        }

                                        //serialize and send to client
                                        Packet.Serialize(this.success).CopyTo(w_buffer, 0);
                                        send();

                                        break;
                                    }

                                default:
                                    {
                                        bt_start.ForeColor = Color.Black;
                                        bt_start.Text = "start";
                                        this.is_connected = false;
                                        break;
                                    }
                            }
                        }

                    }


                }

                //if already connected or n_read == 0, disconnect
                if (this.stream != null)
                {
                    this.stream.Close();
                    this.stream = null;
                }

                if (this.listener != null)
                {
                    this.listener.Stop();
                    this.listener = null;
                }

                this.is_connected = false;

                //change start button
                bt_start.ForeColor = Color.Black;
                bt_start.Text = "start";

                lv_member.Items.Clear();

                tb_log.AppendText("client disconnected or receive wired packet...!\n");
            }));
            
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(receive));
            thread.Start();
        }
    }
}
