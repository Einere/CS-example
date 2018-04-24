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
using System.IO;
using System.Threading;
using insta_packet;

namespace insta_server
{
    public partial class Client : Form
    {
        private NetworkStream stream = null;
        private TcpClient client = null;
        private StreamReader f_reader = null;
        private StreamWriter f_writer = null;
        private bool is_connected = false;
        private bool is_login = false;
        private Thread thread;
        private static int size = 1024 * 5;
        private byte[] r_buffer = new byte[size];
        private byte[] w_buffer = new byte[size];
        public Flag success = null;
        public Member member = null;

        public Client()
        {
            InitializeComponent();
            tb_id.Visible = false;
            tb_password.Visible = false;
            bt_login.Visible = false;
            bt_signup.Visible = false;
        }

        private void pb_home_icon_Click(object sender, EventArgs e)
        {
            pn_home.Visible = true;
            pn_search.Visible = false;
            pn_upload.Visible = false;
            pn_mypage.Visible = false;
        }

        private void pb_search_icon_Click(object sender, EventArgs e)
        {
            pn_home.Visible = false;
            pn_search.Visible = true;
            pn_upload.Visible = false;
            pn_mypage.Visible = false;
        }

        private void pb_upload_icon_Click(object sender, EventArgs e)
        {
            pn_home.Visible = false;
            pn_search.Visible = false;
            pn_upload.Visible = true;
            pn_mypage.Visible = false;
        }

        private void pb_mypage_icon_Click(object sender, EventArgs e)
        {
            pn_home.Visible = false;
            pn_search.Visible = false;
            pn_upload.Visible = false;
            pn_mypage.Visible = true;
        }

        public void send()
        {
            if(this.stream != null)
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

        private void bt_signup_Click(object sender, EventArgs e)
        {
            if (this.is_connected)
            {
                //set packet to send
                Member mem = new Member();
                mem.Type = (int)PacketType.member;
                mem.ID = this.tb_id.Text;
                mem.password = this.tb_password.Text;

                //serialize packet
                Packet.Serialize(mem).CopyTo(this.w_buffer, 0);
                this.send();
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close socket and stream
            if (this.client != null) this.client.Close();
            if (this.stream != null) this.stream.Close();
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            //check if connected
            if (!this.is_connected)
            {
                //make client socket
                this.client = new TcpClient();
                try
                {
                    //connect to server
                    this.client.Connect(this.tb_ip.Text, int.Parse(this.tb_port.Text));
                }
                catch
                {
                    MessageBox.Show("connect error");
                    return;
                }

                this.is_connected = true;
                //get stream
                this.stream = this.client.GetStream();

                //set visible textbox and button
                tb_id.Visible = true;
                tb_password.Visible = true;
                bt_login.Visible = true;
                bt_signup.Visible = true;

                //set this button to "disconnect"
                bt_connect.ForeColor = Color.OrangeRed;
                bt_connect.Text = "disconnect";
            }
            else
            {
                //close stream
                if (this.stream != null)
                {
                    this.stream.Close();
                    this.stream = null;
                }

                //close socket
                if(this.client != null)
                {
                    //this.client.Close();
                    //this.client = null;
                }

                this.is_connected = false;

                //set invisible textbox and button
                tb_id.Visible = true;
                tb_password.Visible = true;
                bt_login.Visible = true;
                bt_signup.Visible = true;

                //set this button to "connect"
                bt_connect.ForeColor = Color.Black;
                bt_connect.Text = "connect";
            }
        }

        private void bt_login_Click(object sender, EventArgs e)
        {

        }
    }
}
