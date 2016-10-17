using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlymaskinenServer
{
    internal class Graph
    {
        private static Graph instance = null;

        private string afbudsdata = "defaultafbud";
        private string forbindelsesfjerner = "defaultfjerner";
        public List<By> byliste = new List<By>();
        private Random random = new Random();
        private int count = 0;
        //int count2 = 0;

        private Graph()
        {
            Thread tråd = new Thread(StartAfbudsPris);
            TilføjBy("København"); // 0
            TilføjBy("Oslo"); // 1
            TilføjBy("Stockholm"); // 2
            TilføjBy("Paris"); // 3 
            TilføjBy("London"); // 4 
            TilføjBy("Dublin"); // 5 
            TilføjBy("Rom"); // 6 
            TilføjBy("Berlin"); // 7

            ForbindGraf();
            tråd.Start();


        }
        private void StartAfbudsPris()
        {
            for (int i = 0; i <= byliste.Count * (byliste.Count - 1); i++)
            {
                Thread.Sleep(1000);
                afbudsdata = SetAfbudsPris();
                Console.WriteLine(afbudsdata);
                Thread.Sleep(1000);
                forbindelsesfjerner = FjernForbindelse();
                Console.WriteLine(forbindelsesfjerner);
            }
        }
        public string GetAfbud()
        {
            //afbudsdata = SetAfbudsPris();
            return afbudsdata;
        }

        public string GetFjerner()
        {
            //forbindelsesfjerner = FjernForbindelse();
            return forbindelsesfjerner;
        }


        public static Graph Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Graph();
                }
                return instance;
            }
        }       

        public void ForbindGraf()
        {

            for (int i = 0; i < byliste.Count; i++)
            {
                for (int x = 0; x < byliste.Count; x++)
                {
                    if (byliste[i] != byliste[x]) // for ikke at lave Rute til sig selv.
                    {
                        Rute Rute = new Rute();

                        Rute.By = byliste[x];// end lokation

                        Rute.pris = random.Next(400, 901);

                     //   Console.WriteLine("Rute mellem " + byliste[i].navn + " og " + byliste[x].navn + " er " + Rute.pris.ToString());

                        byliste[i].Ruteliste.Add(Rute);

                    }
                }
            }

        }

        public void TilføjBy(string navn)
        {
            By v = new By(navn);
            byliste.Add(v);
        }

        public void TilføjForbindelse(String VertexBegin, String VertexEnd, double edgeWeight)
        {
            Rute Rute = new Rute();
            Rute.By = getBy(VertexEnd);
            Rute.pris = edgeWeight;
            getBy(VertexBegin).Ruteliste.Add(Rute);
        }

        public List<string> FindBilligsteRute(String startByNavn, String slutByNavn)
        {
            List<string> gemmer = new List<string>();
            //string gemmer1 = " ";
            Console.WriteLine();
           // gemmer += ("--------------------- From " + navnPaaStartVertex + " to " + navnPaaStopVertex + " ----------------");
            Console.WriteLine();
            List<By> priorityQueue = new List<By>();
            By startBy = getBy(startByNavn);
            startBy.Visited = true;
            startBy.PrisFraStartBy = 0;
            priorityQueue.Add(startBy); //putter det første element i køen
            By frontBy = startBy;
            Boolean search = true;
            while (priorityQueue.Count > 0 && search)
            {
                //---- Prioritizing from the Queue-----
                int value = 1000000000;
                int teller = 0;
                foreach (By v in priorityQueue)
                {
                    if (v.PrisFraStartBy < value)
                    {
                        frontBy = priorityQueue[teller];
                        value = v.PrisFraStartBy;
                    }
                    teller++;
                }
                priorityQueue.Remove(frontBy);
                frontBy.Visited = true;
                //Console.WriteLine(" <- Dequeue: " + frontBy.Navn + " with pris: " + frontBy.PrisFraStartBy + " Queue size:" + priorityQueue.Count);
                //----Prioritizing STOP-------------------------------------------
                //-----We have found the By-------------------------------------

                // NU har vi fundet den mindste i grafen


                if (frontBy.Navn.Equals(slutByNavn)) //hvis vi nu finder den rigtige By så går den herind
                {
                    gemmer.Add("REJSE \t ---------- Found: Name: " + frontBy.Navn + " pris: " + frontBy.PrisFraStartBy+ "\t");
                    By holder = frontBy;
                    while (!holder.Navn.Equals(startByNavn))
                    {
                        gemmer.Add("REJSE backtracking: " + holder.Navn + "\t");
                        holder = holder.SidsteBy;
                    }
                    gemmer.Add("REJSE backtracking: " + startByNavn);
                    search = false;
                    break;
                    
                }
                //--------------------------------------
                foreach (Rute e in frontBy.Ruteliste) //flyt børnene, hvis de er mindre og ikke er visited.
                {
                    // lidt indviklet: Først må vi tjekke for at vertexen ikke allerede er
                    // besøgt. Det er den første if sætning. Siden må vi tjekke om vægten
                    // således at vi ikke overskriver en By som allerede er i køen, og
                    // som har en mindre vægt. Har den mindre vægt, så skal den nye ikke med
                    // i køen. Men om den ny nu har mindre vægt end en som allerede er i køen,
                    // så overskriver vi denne, i stedet for at lave en ny reference, det er if else
                    // sætningen.
                    int w = (int)e.pris;
                    if (e.By.Visited == false) //Den er ikke besøgt før, så skal den med.
                    {
                        Boolean laengdeOK = true;
                        Boolean mindreOK = false;
                        foreach (By v in priorityQueue)// Hvis længden er større på den ny, skal
                        { // den heller ikke med her.
                            if (v.Navn.Equals(e.By.Navn)) //skal først finde samme By navn
                            {
                                if (frontBy.PrisFraStartBy + w >= v.PrisFraStartBy) //hvis length og w er større end den var tidligere, altså en vej der er mindre fra start til barnet.
                                {
                                    laengdeOK = false;
                                }
                                else
                                {
                                    mindreOK = true;
                                }
                            }
                        }
                        if (laengdeOK == true && mindreOK == false) //Add'es til køen da der ikke er sket noget med vertexen // ADD
                        {
                            e.By.PrisFraStartBy = frontBy.PrisFraStartBy + w;
                            e.By.SidsteBy = frontBy;
                            priorityQueue.Add(e.By);
                            //Console.WriteLine(" -> Enqueing: " + e.By.Navn + " pris: " + e.By.PrisFraStartBy + " Previous By: " + e.By.SidsteBy.Navn + " Queue size:" + priorityQueue.Count);
                        }
                        else if (laengdeOK == true && mindreOK == true)// Så er By´en allered i Køen, Så overskriver vi bare, //OVERSKRIV
                        { // i stedet for at lægge endnu en reference af samme objekt i køen.
                            By v = getBy(e.By.Navn);
                            v.PrisFraStartBy = frontBy.PrisFraStartBy + w;
                            v.SidsteBy = frontBy;
                            //Console.WriteLine(" * Overskriver By " + e.By.Navn + " pris: " + e.By.PrisFraStartBy);
                        }
                        else if (laengdeOK == false && mindreOK == false) // findes allerede og har den mindste vægt /DONT ADD 
                        {
                            //Console.WriteLine(" * Findes allerede og har mindre eller samme vægt: " + e.By.Navn);
                            
                        }
                    }
                    else
                    {
                        //Console.WriteLine(" * Besøgt By før: " + e.By.Navn);
                    }
                }
            }
            return gemmer ;
        }

        public int Rutetæller() //tjek om der er flere rejser
        {
            int rejser = 0;
            for (int i = 0; i < byliste.Count; i++)
            {
                int ruter = byliste[i].Ruteliste.Count;
                if (ruter > rejser)
                {
                    rejser = ruter;
                }
            }
            return rejser;
        }

        public string FjernForbindelse() //ændret til string
        {
            // metoden skal fjerne noget uanset hvad!
            string fjerner = "";
            //Console.WriteLine("FjernForbindelse:   " + countfjern);
            bool fundet = false;
            while (fundet == false)
            {
                int tjekker = Rutetæller();
                if (tjekker == 0)
                {
                    fundet = true;
                    fjerner = "Alle rejser er nedlagt";
                }
                else
                {
                    int fraby = random.Next(0, byliste.Count);

                    while (byliste[fraby].Ruteliste.Count == 0)
                    {
                        fraby = random.Next(0, byliste.Count);
                    }
                    int tilby = random.Next(0, byliste[fraby].Ruteliste.Count);
                    string a = byliste[fraby].Navn;
                    string b = byliste[fraby].Ruteliste[tilby].By.Navn;

                    foreach (By by in byliste)
                    {
                        if (by.Navn.Equals(a))
                        {
                            foreach (Rute rut in by.Ruteliste)
                            {
                                if (rut.By.Navn.Equals(b))
                                {
                                    string by1 = by.Navn;
                                    string by2 = rut.By.Navn;
                                    fjerner = "NEDLAGT rute: start by " + by1 + " fjerner slutby " + by2;
                                    by.Ruteliste.Remove(rut);

                                    //countfjern++;
                                    fundet = true;
                                    return fjerner;
                                }
                            }
                        }
                    }
                }
            }
            //Thread.Sleep(5000);
            return fjerner;
        }

        public string UdskrivForbindelser()
        {
            string gem = " ";
            foreach (By b in byliste)
            {
                foreach (Rute forbindelse in b.Ruteliste)
                {
                    if (forbindelse != null)
                    {
                        count++;
                        gem += (b.Navn + " til " + forbindelse.By.Navn + "        \t pris:  " + forbindelse.pris + "\n");
                        
                    }
                }
            }
            return gem; 
        }

        public string SetAfbudsPris() //skal måske sendes videre til en void metode, for at kunne trådes
        {
           
            bool exit = false;
            int afbudspris = random.Next(200, 300);

            //  int afbudspris = random.Next(min, max);
            string afbud = "";

            // sætter afbudspris.

            while (exit == false)
            {
                //FjernForbindelse(); //hvorfor sende parametre med, hvis det kan være ruten ikke eksisterer længere?
                //jeg har derfor fjernet input parametre og sat dem ind i metoden
                int a = random.Next(0, byliste.Count);
                int b = random.Next(0, byliste[a].Ruteliste.Count); // b er blevet indsat som a's rute.count.

                if (byliste[a].Ruteliste.Count == 0) //hvis der ingen ruter er længere fra by a, så random igen
                {
                    int rejser = Rutetæller();

                    if (rejser != 0)
                    {
                        a = random.Next(0, byliste.Count);
                        b = random.Next(0, byliste[a].Ruteliste.Count); // her er b blevet ændert til a's rute.count  
                    }
                    else if (rejser == 0)
                    {
                        afbud = "Der er ikke flere rejser";
                        exit = true;
                    }
                }

                if (byliste[a].Ruteliste.Count > 0) //så længe der er rejser fra a, så kør
                {

                    byliste[a].Ruteliste[b].pris = afbudspris;
                    afbud = "AFBUD Prisen mellem " + byliste[a].Navn + " og " + byliste[a].Ruteliste[b].By.Navn + " er nu " + afbudspris;
                    afbudsdata = afbud; 
                    exit = true;
                }

            }

            count++; // counter fordi der er blevet fjernet 1 forbindelse og sat en afbudsrejse på 1 forbindelse



            exit = false;
            Thread.Sleep(5000);
            return afbud;
        }

        public void GetafbudsData()
        {
            Console.WriteLine(afbudsdata);
        }

        public By findTheVertexWithMostEdges()
        {
            int flestvertex = 0;
            By vert = null;



            foreach (By v in byliste)
            {
                if (v.Ruteliste.Count > flestvertex)
                {
                    flestvertex = v.Ruteliste.Count;
                    vert = v;

                }
            }


            return vert;
        }
        public void findShortesPathUnweightedGraph(String navnPaaStartVertex)
        {
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getBy(navnPaaStartVertex);
            startVertex.Visited = true;
            startVertex.PrisFraStartBy = 0;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                frontVertex = vertexQueue.Dequeue();
                foreach (Rute e in frontVertex.Ruteliste)
                {
                    if (e.By.Visited == false)
                    {
                        e.By.Visited = true;
                        e.By.PrisFraStartBy = frontVertex.PrisFraStartBy + 1;
                        e.By.SidsteBy = frontVertex;
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                    }
                }
            }
            Console.WriteLine("-------- Shortes Path in an Unweighted Graph-------------");
            Console.WriteLine("-------- From By: " + navnPaaStartVertex + " to all other rechable By-------");
            foreach (By v in traversalOrder)
            {
                Console.Write("Name: " + v.Navn + " Distance: " + v.PrisFraStartBy + " - ");
            }
            Console.WriteLine();
        }
        public Boolean isThereAConnection(String a, String b)
        {
            Boolean fundet = false;
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getBy(a);
            startVertex.Visited = true;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                frontVertex = vertexQueue.Dequeue();
                foreach (Rute e in frontVertex.Ruteliste)
                {
                    if (e.By.Visited == false)
                    {
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.Visited = true;
                        if (e.By.Navn.Equals(b))
                        {
                            fundet = true;
                        }
                    }
                }
            }
            return fundet;
        }
        public By getBy(String navn)
        {
            By gemmer = null;
            foreach (By By in byliste)
            {
                if (By.Navn.Equals(navn))
                {
                    gemmer = By;
                }
            }
            return gemmer;
        }
        public void setAllToNotVisited()
        {
            foreach (By v in byliste)
            {
                v.Visited = false;
            }
        }
        public void printGraph()
        {
            foreach (By v in byliste)
            {
                foreach (Rute e in v.Ruteliste)
                {
                    Console.WriteLine("From: " + v.Navn + " To: " + e.By.Navn + " pris: " + e.pris);
                }
            }
        }
        public void BreathFirstTraversal(String navnPaaStartVertex)
        {
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getBy(navnPaaStartVertex);
            startVertex.Visited = true;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                Console.WriteLine("Items in Queue: " + vertexQueue.Count);
                frontVertex = vertexQueue.Dequeue();
                Console.WriteLine(" <- Dequeue: " + frontVertex.Navn + " frontVertex");
                foreach (Rute e in frontVertex.Ruteliste)
                {
                    if (e.By.Visited == false)
                    {
                        Console.WriteLine(" -> Enqueue: " + e.By.Navn);
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.Visited = true;
                    }
                }
            }
            Console.Write(" Traversal order: ");
            foreach (By v in traversalOrder)
            {
                Console.Write(v.Navn + " ");
            }
            Console.WriteLine();
        }
        public void DepthFirstTraversal(String navnPaaStartVertex)
        {
            Stack<By> vertexStack = new Stack<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getBy(navnPaaStartVertex);
            startVertex.Visited = true;
            By topVertex;
            vertexStack.Push(startVertex);
            traversalOrder.Enqueue(startVertex);
            while (vertexStack.Count > 0)
            {
                Console.WriteLine("Items in Stack: " + vertexStack.Count);
                topVertex = vertexStack.Pop();
                Console.WriteLine(" <- Pop from stack: " + topVertex.Navn + " topVertex");
                foreach (Rute e in topVertex.Ruteliste)
                {
                    if (e.By.Visited == false)
                    {
                        Console.WriteLine(" -> Push to stack: " + e.By.Navn);
                        vertexStack.Push(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.Visited = true;
                    }
                }
            }
            Console.Write(" Traversal order: ");
            foreach (By v in traversalOrder)
            {
                Console.Write(v.Navn + " ");
            }
            Console.WriteLine();
        }
     
    }
}
