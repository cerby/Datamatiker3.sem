using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlymaskinenClient
{
    class Program
    {
        public static object lockObject = new object();
        static void Main(string[] args)
        {
            TCPLytter Lytter = new TCPLytter();

            Lytter.her();
            
        }        
    }

    class TCPLytter
    {
        public void her()
        {
            TcpClient tcp = new TcpClient();
            tcp.Connect("127.0.0.1",15000);
            NetworkStream s = tcp.GetStream();
            BinaryReader reader = new BinaryReader(s);
            while (true)
            {
                string m = reader.ReadString();
                
                    lock (Program.lockObject)
                    {
                        Console.WriteLine(m);
                    }
                
            }
        }
        
        
    }
}
