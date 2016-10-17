using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace FlymaskinenServer
{
    class ClientHandler
    {


        private Graph graf = Graph.Instance;
        //private int count; 

        private Socket s;
        private NetworkStream socketStream;
        public BinaryWriter writer; // NB public 
        private BinaryReader reader;
        private Hashtable ht;

        /* NYT   */ 

        public ClientHandler(Socket s, Hashtable ht)
        {

            this.s = s;
            socketStream = new NetworkStream(s);
            writer = new BinaryWriter(socketStream);
            reader = new BinaryReader(socketStream);
            this.ht = ht; // access to all sockets from ht.


        }

        /* NYT   */
        public void GetFjernAfbud()
        {
            try
            {
                while (true)
                {
                    for (int i = 0; i <= graf.byliste.Count * (graf.byliste.Count - 1); i++)
                    {
                        //CHFjernData = graf.GetFjerner();
                        SendMessage(graf.GetFjerner());
                        Thread.Sleep(1000);
                        //CHAfbudsdata = graf.GetAfbud();
                        SendMessage(graf.GetAfbud());
                        Thread.Sleep(1000);
                    }
                }
                
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
        }
        /* NYT   */
        //public void Rutefjerner()
        //{
        //    for (int i = 0; i <= graf.byliste.Count * (graf.byliste.Count - 1); i++)
        //    {
        //        Thread.Sleep(2000);
        //        forbindelsesfjerner = graf.FjernForbindelse();
        //        Console.WriteLine(forbindelsesfjerner);
        //        writer.Write(forbindelsesfjerner);
        //    }
        //}
        public void Run()
        {

            try // why this try? try to delete!
            {
                while (true)
                {

                    //>>>>                   //NYT!!
                    //Thread t1 = new Thread(SetAfbudsPris2);
                    //Thread t2 = new Thread(Rutefjerner);
                    //t1.Start();
                    //t2.Start();
                    // applikationsprotokol:
                    string message = reader.ReadString();

                    
                    string[] param = message.Split(' ');
                    string[] test = message.Split(' ');
                    //int operant1 = Convert.ToInt16(param[1]);
                    //int operant2 = Convert.ToInt16(param[2]);
                    string by1 = param[1];
                    string by2 = param[2];

                    if (param[0] == "findrejse")
                    {
                        SendMessage(graf.FindBilligsteRute(by1, by2));

                    }
                    //else if (test[0] == "TILBUDSREJSE")
                    //{
                    //    Console.WriteLine(graf.SetAfbudsPris());
                    //    SendMessage(graf.SetAfbudsPris()); 

                    //}
                    else if (test[0] == "findruter")
                    {
                        SendMessage(graf.UdskrivForbindelser());

                    }
                    else if (param[0] == "findafbudspris")
                    {


                    }
                    else if (param[0] == "nisse")
                    {
                        SendMessage("Nisse");
                    }
                    else
                    {
                        SendMessage("Du har tastet forkert");
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                Console.WriteLine("Client har lukke programmet");
                SendMessage("Der er sket en fejl");
            }
        }
        public void SendMessage(string m)
        {
            writer.Write(m);
        }
    }
}