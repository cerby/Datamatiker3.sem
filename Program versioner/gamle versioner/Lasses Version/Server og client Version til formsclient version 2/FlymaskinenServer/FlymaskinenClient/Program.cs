using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlymaskinenClient
{
    class Program
    {
        public static object lockObject = new object();
        private static void Main(string[] args)
        {

            //while (true)
            //{
            //    TcpClient tcpclient = new TcpClient();
            //    tcpclient.Connect("127.0.0.1", 15000);
            //    // tcpclient.Connect("10.140.82.162", 65000);
            //    NetworkStream s = tcpclient.GetStream();
            //    BinaryReader r = new BinaryReader(s);
            //    BinaryWriter w = new BinaryWriter(s);

            //    Console.WriteLine("Velkommen til dit nye rejse program");
            //    Console.WriteLine("For at finde den billigste rejse mellem 2 byer skal du indtaste ");
            //    Console.WriteLine("'Findrejse Berlin Rom' og så kommer den billigste rejse frem ");
            //    Console.WriteLine("Du kan også indtaste 'Tilbudsrejse  + 2 mellemrum ");
            //    Console.WriteLine("og så komme rejsen der er på tilbud frem");



            //    w.Write(Console.ReadLine());

            //    string svar = r.ReadString();
            //    Console.WriteLine(svar);



               


                //TCPLytter lytter = new TCPLytter();

                //lytter.her();
            //}

        }
    }

    class TCPLytter
    {
        public void her()
        {
            TcpClient tcp = new TcpClient();
            tcp.Connect("127.0.0.1", 15000);
            NetworkStream s = tcp.GetStream();
            BinaryReader reader = new BinaryReader(s);
            while (true)
            {
                string m = reader.ReadString(); //er det ikke den her der skal lockes? 

                lock (Program.lockObject)
                {
                    Console.WriteLine(m);
                }

            }
        }

    }
}
    

