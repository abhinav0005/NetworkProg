using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace NetworkProg
{
    /// <summary>
    /// Prog to Shoe IPaddress
    /// </summary>
    public class Program
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            ///<summary>
            ///Dns.GetHostName() returns the name of the local machine 
            /// </summary>
            string name = (args.Length < 1) ? Dns.GetHostName() : args[0];
            try
            {

                /// Dns.Resolve() returns IPHostEntry for a machine with a given name 
                ///the AddressList property of which returns the IPAdresses of the machine
                IPAddress[] addrs = Dns.Resolve(name).AddressList;
                
                foreach (IPAddress addr in addrs)
                    Console.WriteLine("{0}/{1}", name, addr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
