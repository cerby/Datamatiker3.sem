using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic; // Hashtable
 

namespace FlymaskinenServer
{
    class Program
    {
          // nickname , clienthandler:
        private static Hashtable ht = new Hashtable();
        static void Main(string[] args)
        {

           
             // setup:
            //IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            IPAddress ipAd = IPAddress.Parse("10.140.81.84");
            TcpListener myList = new TcpListener(IPAddress.Any, 15000);

            // Start listening:
            Console.WriteLine("The server is running at port 15000");
            myList.Start();
            Console.WriteLine("Waiting for connections");
            while (true)
            {
                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                NetworkStream socketStream = new NetworkStream(s);
                BinaryReader reader = new BinaryReader(socketStream);

                // Application protocol here:
                //string nickname = reader.ReadString();
                //Console.WriteLine("Recieved nickname: " + nickname);

                ClientHandler ch = new ClientHandler(s, ht);
                //lock (new object())
                //    ht[nickname] = ch; // for future use;
                Thread th = new Thread(ch.Run);
                Thread th2 = new Thread(ch.GetFjernAfbud);
                th2.Start();
                th.Start();
                
                
                 
            }
            // cleanup, never reached !!!
            //myList.Stop();
        }
    }
}


