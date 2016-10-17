using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic; // Hashtable

namespace Server
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
        private string afbudsdata;
        private string fjernforb;

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
                        afbudsdata = graf.SetAfbudsPris();
                        SendMessage(afbudsdata);
                        Thread.Sleep(3000);
                        fjernforb = graf.FjernForbindelse();
                        SendMessage(fjernforb);
                        Thread.Sleep(3000);
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
                    string webbesked = "";

                    message = message.ToUpper();
                    string[] param = message.Split(' ');
                    string[] test = message.Split(' ');
                    //int operant1 = Convert.ToInt16(param[1]);
                    //int operant2 = Convert.ToInt16(param[2]);
                    string by1 = param[1];
                    string by2 = param[2];

                    if (param[0] == "FINDREJSE")
                    {
                        List<string> rejseList = graf.FindBilligsteRute(by1, by2);
                        foreach (string rejse in rejseList)
                        {
                            SendMessage(rejse);
                        }
                        graf.setAllToNotVisited();

                    }
                    else if (param[0] == "FINDWEBREJSE")
                    {
                        List<string> rejseList = graf.FindBilligsteRute(by1, by2);
                        foreach (string rejse in rejseList)
                        {
                            webbesked += rejse;
                        }
                        SendMessage(webbesked);
                        graf.setAllToNotVisited();
                    }

                    else if (test[0] == "FINDRUTER")
                    {
                        SendMessage(graf.UdskrivForbindelser());

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
