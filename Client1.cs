using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client1
{
    class Program
    {
        static Socket sck;
        static void Main(string[] args)
        {
            // Create a TCP/IP  socket.
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                // Connect the socket to the remote endpoint
                sck.Connect(localEndPoint);
                Console.WriteLine("Connected");
            }
            catch
            {
                Console.WriteLine("unable to connect to the end point!\r\n");
                Main(args);
            }
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            // Encode the data string into a byte array
            byte[] data = Encoding.ASCII.GetBytes(text);
            // Send the data through the socket.
            sck.Send(data);
            Console.WriteLine("Data Sent!\r\n");
            Console.WriteLine("Press any key to continue...");
            sck.Close();
            Console.Read();
        }
    }
}
