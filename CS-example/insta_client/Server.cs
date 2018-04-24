using System;
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
        private Thread thread;
        private delegate void Delegator();
        private Delegator delegator;
        private static int size = 1024 * 5;
        private byte[] r_buffer = new byte[size];
        private byte[] w_buffer = new byte[size];
        public Flag success = null;
        public Member member = null;

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

        private void bt_start_Click(object sender, EventArgs e)
        {
            //if not complete ip & port textbox
            if (tb_ip.TextLength == 0 || tb_port.TextLength == 0)
            {
                MessageBox.Show("please type IP and port");
                return;
            }

            //check file is exist, open or return
            if (File.Exists("member.txt"))
            {
                try
                {
                    f_reader = new StreamReader("member.txt");
                }
                catch
                {
                    MessageBox.Show("failed to open stream reader");
                    this.listener.Stop();
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("file isn't exist");
                File.Create("member.txt"); // need to write encoding argument
                return;
            }

            //check client is connected or not
            if (!this.is_connected)
            {
                //waiting client
                if (this.listener == null) this.listener = new TcpListener(Int32.Parse(tb_port.Text));
                this.listener.Start();

                //if not connected
                this.Invoke(new MethodInvoker(delegate ()
                {
                    tb_log.AppendText("waiting for client...\n");
                }));

                //set offset to head
                if (this.f_reader.Peek() < 0) this.f_reader.BaseStream.Seek(0, SeekOrigin.Begin);
                //get data from text file
                int i = 1;
                //set item and add at list view
                while(f_reader.Peek() != null)
                {
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(f_reader.ReadLine());
                    item.SubItems.Add(f_reader.ReadLine());
                    lv_member.Items.Add(item);
                }
                
                

                //get client socket
                TcpClient client = this.listener.AcceptTcpClient();

                //if connected
                if (client.Connected)
                {
                    this.is_connected = true;

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        //change start button
                        bt_start.ForeColor = Color.OrangeRed;
                        bt_start.Text = "stop";

                        tb_log.AppendText("client connected...!\n");
                    }));

                    //get client stream
                    this.stream = client.GetStream();
                    
                    //read data from client until disconnection. 스레드로 만들어야 될 것 같다 (신호 수신용)
                    while (this.is_connected)
                    {
                        int n_read = 0;

                        try
                        {
                            n_read = 0;
                            //read data from stream to r_buffer
                            n_read = this.stream.Read(r_buffer, 0, size);
                        }
                        catch
                        {
                            this.is_connected = false;
                            this.stream = null;
                        }

                        //get packet and switch 
                        if (this.r_buffer == null)
                        {
                            MessageBox.Show("r_buffer is null");
                            return;
                        }

                        //need to deal when disconnecting signal recieved
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
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        string msg = String.Format("flag packet : success = {0}, ", this.success.seccess.ToString());
                                        MessageBox.Show(msg);
                                    }));
                                    break;
                                }
                            case (int)PacketType.member:
                                {
                                    this.member = (Member)Packet.Deserialize(this.r_buffer);
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        string msg = String.Format("member packet : id = {0}, password = {1}", this.member.ID, this.member.password);
                                        MessageBox.Show(msg);
                                    }));
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

            this.Invoke(new MethodInvoker(delegate ()
            {
                //change start button
                bt_start.ForeColor = Color.Black;
                bt_start.Text = "start";

                tb_log.AppendText("client disconnected or receive wired packet...!\n");
            }));

        }
    }
}
