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

namespace CS_example_winform
{
    public partial class Ch06_Ex03 : Form
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Wirte;
        const int PORT = 2002;
        private Thread m_thReader;

        public bool m_bStop = false;
        private TcpListener m_listner;
        private Thread m_thServer;

        public bool m_bConnect = false;
        TcpClient m_Client;

        public Ch06_Ex03()
        {
            InitializeComponent();
        }

        private void Ch06_Ex03_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txt_all.AppendText(msg + "\n");
                txt_all.Focus();
                txt_all.ScrollToCaret();
                txt_send.Focus();
            }));
        }

        public void ServerStart()
        {
            try
            {
                m_listner = new TcpListener(PORT);
                m_listner.Start();

                m_bStop = true;
                Message("waiting for connection from client");

                while (m_bStop)
                {
                    Socket hClient = m_listner.AcceptSocket();
                    if (hClient.Connected)
                    {
                        m_bConnect = true;
                        Message("client connected");

                        m_Stream = new NetworkStream(hClient);
                        m_Read = new StreamReader(m_Stream);
                        m_Wirte = new StreamWriter(m_Stream);

                        m_thReader = new Thread(new ThreadStart(Receive));
                        m_thReader.Start();
                    }
                }
            }
            catch
            {
                Message("error occurred during starting server");
                return;
            }
        }

        public void ServerStop()
        {
            if (!m_bStop) return;

            m_listner.Stop();
            m_Read.Close();
            m_Wirte.Close();
            m_Stream.Close();
            m_thReader.Abort();
            m_thServer.Abort();

            Message("server is stopeed");
        }

        public void Connect()
        {
            m_Client = new TcpClient();

            try
            {
                m_Client.Connect(txt_ServerIp.Text, PORT);

            }
            catch
            {
                m_bConnect = false;
                return;
            }

            m_bConnect = true;
            Message("connected to server");

            m_Stream = m_Client.GetStream();
            m_Read = new StreamReader(m_Stream);
            m_Wirte = new StreamWriter(m_Stream);
            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();

        }

        public void Disconnect()
        {
            if (!m_bConnect) return;

            m_bConnect = false;
            m_Read.Close();
            m_Wirte.Close();
            m_Stream.Close();
            m_thReader.Abort();

            Message("disconnect to server");
        }

        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    string szMessage = m_Read.ReadLine();

                    if (szMessage != null) Message("other : " + szMessage);
                }
            }
            catch
            {
                Message("error occurred during reading data");
            }

            Disconnect();
        }

        public void Send()
        {
            try
            {
                m_Wirte.WriteLine(txt_send.Text);
                m_Wirte.Flush();

                Message(">>> : " + txt_send.Text);
                txt_send.Text = "";
            }
            catch
            {
                Message("failed to send message");
            }
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            if(btn_Server.Text == "server start")
            {
                m_thServer = new Thread(new ThreadStart(ServerStart));
                m_thServer.Start();

                btn_Server.Text = "server stop";
                btn_Server.ForeColor = Color.Red;
            }
            else
            {
                ServerStop();
                btn_Server.Text = "server start";
                btn_Server.ForeColor = Color.Black;
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if(btn_Connect.Text == "server connect")
            {
                Connect();
                if (m_bConnect)
                {
                    btn_Connect.Text = "server disconnect";
                    btn_Connect.ForeColor = Color.Red;
                }
                else
                {
                    Disconnect();
                    btn_Connect.Text = "server connect";
                    btn_Connect.ForeColor = Color.Black;
                }
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Send();
        }
    }

    
}
