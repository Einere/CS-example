using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ch06_Ex03_01;
using System.Net;
using System.Net.Sockets;

namespace Ch06_Ex03_03
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private NetworkStream m_networkstream;
        private TcpClient m_client;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        private bool m_bConnect = false;
        public Initialize m_initializeClass;
        public Login m_loginClass;

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++) this.sendBuffer[i] = 0;
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_bConnect = false;
            if(this.m_client != null) this.m_client.Close();
            if(this.m_networkstream != null) this.m_networkstream.Close();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            this.m_client = new TcpClient();
            try
            {
                this.m_client.Connect(this.txt_ip.Text, 7777);
            }
            catch
            {
                MessageBox.Show("connect error!");
                return;
            }
            this.m_bConnect = true;
            this.m_networkstream = this.m_client.GetStream();
        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect) return;

            Initialize Init = new Initialize();
            Init.Type = (int)PacketType.init;
            Init.Data = Int32.Parse(this.txt_init.Text);

            Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
            this.Send();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect) return;
            Login login = new Login();
            login.Type = (int)PacketType.login;
            login.m_strID = this.txt_login.Text;

            Packet.Serialize(login).CopyTo(this.sendBuffer, 0);
            this.Send();
        }
    }
}
