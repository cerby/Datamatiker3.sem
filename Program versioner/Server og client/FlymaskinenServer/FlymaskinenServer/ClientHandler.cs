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
        private string CHFjernData;
        private string CHAfbudsdata;

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
                        Thread.Sleep(5000);
                        //CHFjernData = graf.GetFjerner();
                        SendMessage(graf.GetFjerner());
                        Thread.Sleep(5000);
                        //CHAfbudsdata = graf.GetAfbud();
                        SendMessage(graf.GetAfbud());
                        Thread.Sleep(5000);

                        Console.WriteLine("Fjern : "+i);
                    }
                }
                
            }
            catch (Exception exc)
            {
                
               

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

                    message = message.ToUpper();
                    string[] param = message.Split(' ');
                    string[] test = message.Split(' ');
                    //int operant1 = Convert.ToInt16(param[1]);
                    //int operant2 = Convert.ToInt16(param[2]);
                    string by1 = param[1];
                    string by2 = param[2];

                    if (param[0] == "FINDREJSE")
                    {
                        SendMessage(graf.FindBilligsteRute(by1, by2));
                        graf.setAllToNotVisited();

                    }
                    else if (test[0] == "TILBUDSREJSE")
                    {
                        SendMessage( graf.GetAfbud()+"\n");

                    }
                    else if (test[0] == "FINDRUTER")
                    {
                        SendMessage(graf.UdskrivForbindelser());

                    }
                    else if (test[0] == "FJERNREJSER")
                    {

                        SendMessage(graf.GetFjerner() + "\n");
                    }
                  
                    else
                    {
                        SendMessage("Du har tastet forkert");
                    }
                }
            }
            catch (Exception exc)
            {
                
                
                Console.WriteLine("Client har lukke programmet");
               
            }
        }
        public void SendMessage(string m)
        {
            writer.Write(m);
        }
    }
}