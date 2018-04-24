using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Network01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 13000;

            try
            {
                server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    Console.WriteLine("waiting for connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("connected...");

                    DateTime t = DateTime.Now;
                    string message = string.Format("message from server : {0}", t.ToString("yyyy-mm-dd hh:mm:ss"));
                    byte[] writeBuffer = Encoding.UTF8.GetBytes(message);

                    int bytes = writeBuffer.Length;
                    byte[] writeBufferSize = BitConverter.GetBytes(bytes);

                    NetworkStream stream = client.GetStream();
                    stream.Write(writeBufferSize, 0, writeBufferSize.Length);
                    Console.WriteLine("sent : {0}", bytes);

                    stream.Write(writeBuffer, 0, writeBuffer.Length);
                    Console.WriteLine("sent : {0}", message);

                    stream.Close();
                    client.Close();
                    Console.WriteLine();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("socket exception : {0}", e);
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nserver closed");
        }
    
    }
}
