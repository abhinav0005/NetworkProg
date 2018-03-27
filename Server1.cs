using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkProg
{
    class ServerNetwork1
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            try
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sck.Bind(new IPEndPoint(0,1234));
                Console.WriteLine("server startup ...");
                sck.Listen(100);
                Socket accepted = sck.Accept();
                Buffer = new byte[accepted.SendBufferSize];
                int bytesRead = accepted.Receive(Buffer);
                byte[] formatted = new byte[bytesRead];
                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = Buffer[i];
                }
                string strData = Encoding.ASCII.GetString(formatted);
                Console.Write(strData + "\n");
                Console.Read();
                sck.Close();
                accepted.Close();
            }
            catch(Exception e)
            {
                Console.Read();
            }            
            Console.Read();
        }
    }
}
