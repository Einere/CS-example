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
using Ch06_Ex03_01;


namespace Ch06_Ex03_02
{
    public partial class Server : Form
    {
        private NetworkStream m_networkstream;
        private TcpListener m_listener;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        private bool m_bClientOn = false;
        private Thread m_thread;
        public Initialize m_initializeClass;
        public Login m_loginClass;

        public Server()
        {
            InitializeComponent();
        }

        public void RUN()
        {
            //open listener
            this.m_listener = new TcpListener(7777);
            this.m_listener.Start();

            //if client is not connected
            if (!this.m_bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_server_state.AppendText("waiting client access...\n");
                }));
            }

            //wait until client connect to server
            TcpClient client = this.m_listener.AcceptTcpClient();
            
            //if client is connected
            if (client.Connected)
            {
                this.m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate(){
                    this.txt_server_state.AppendText("client connect!\n");
                }));
                m_networkstream = client.GetStream();
            }

            int nRead = 0;

            //if client is connected
            while (this.m_bClientOn)
            {
                try
                {
                    //read from stream
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bClientOn = false;
                    this.m_networkstream = null;
                }

                //deserialize read buffer
                Packet packet = (Packet)Packet.Deserialize(this.readBuffer);

                //judge which packet type
                switch ((int)packet.Type)
                {
                    case (int)PacketType.init:
                        {
                            this.m_initializeClass = (Initialize)Packet.Deserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("success to transmit packet.\n" + "Initialize class data is " + this.m_initializeClass.Data + "\n");
                            }));
                            break;
                        }
                    case (int)PacketType.login:
                        {
                            this.m_loginClass = (Login)Packet.Deserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("sucees to transmit packet.\n" + "Login class data is " + this.m_loginClass.m_strID + "\n");
                            }));
                            break;
                        }
                }
            }
        }

        private void Ch06_Ex03_02_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(RUN));
            this.m_thread.Start();
        }

        private void Ch06_Ex03_02_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if(this.m_listener != null) this.m_listener.Stop();
            //if(this.m_networkstream != null) this.m_networkstream.Close();
            //if(this.m_thread != null) this.m_thread.Abort();
            this.m_bClientOn = false;
            this.m_listener.Stop();
            this.m_networkstream.Close();
            this.m_thread.Abort();
        }
    }
}
