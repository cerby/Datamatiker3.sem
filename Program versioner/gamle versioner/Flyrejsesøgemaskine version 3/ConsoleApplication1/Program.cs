using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyrejsesøgemaskine_version_2_lokal
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graf = new Graph();

            graf.TilføjBy("København");  // 0
            graf.TilføjBy("Oslo");       // 1
            graf.TilføjBy("Stockholm");  // 2
            graf.TilføjBy("Paris");      // 3 
            graf.TilføjBy("London");     // 4 
            graf.TilføjBy("Dublin");     // 5 
            graf.TilføjBy("Rom");        // 6 
            graf.TilføjBy("Berlin");     // 7

            graf.ForbindGraf();

            graf.FjernForbindelse("København", "London");

            Console.WriteLine("-----------------------------");
            
            graf.SetAfbudsPris(200,300);

            graf.udskrivForbindelser();

        }
    }
    class Graph
    {
        List<By> byliste = new List<By>();
        Random random = new Random();
        int count = 0;
        int count2 = 0;

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

                        Rute.pris = random.Next(400, 900);

                      //  Console.WriteLine("Rute mellem " + byliste[i].navn + " og " + byliste[x].navn + " er " + Rute.pris.ToString());

                        byliste[i].ruteliste.Add(Rute);

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
            Rute.By = getVertex(VertexEnd);
            Rute.pris = edgeWeight;
            getVertex(VertexBegin).ruteliste.Add(Rute);
        }

        public void FindBilligsteRute(String navnPaaStartVertex, String navnPaaStopVertex)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------- From " + navnPaaStartVertex + " to " + navnPaaStopVertex + " ----------------");
            Console.WriteLine();
            List<By> priorityQueue = new List<By>();
            By startVertex = getVertex(navnPaaStartVertex);
            startVertex.visited = true;
            startVertex.lengthFromStartVertex = 0;
            priorityQueue.Add(startVertex); //putter det første element i køen
            By frontVertex = startVertex;
            Boolean search = true;
            while (priorityQueue.Count > 0 && search)
            {
                //---- Prioritizing from the Queue-----
                int value = 1000000000;
                int teller = 0;
                foreach (By v in priorityQueue)
                {
                    if (v.lengthFromStartVertex < value)
                    {
                        frontVertex = priorityQueue[teller];
                        value = v.lengthFromStartVertex;
                    }
                    teller++;
                }
                priorityQueue.Remove(frontVertex);
                frontVertex.visited = true;
                Console.WriteLine(" <- Dequeue: " + frontVertex.navn + " with pris: " + frontVertex.lengthFromStartVertex + " Queue size:" + priorityQueue.Count);
                //----Prioritizing STOP-------------------------------------------
                //-----We have found the By-------------------------------------

                // NU har vi fundet den mindste i grafen


                if (frontVertex.navn.Equals(navnPaaStopVertex)) //hvis vi nu finder den rigtige By så går den herind
                {
                    Console.WriteLine(" ---------- Found: Name: " + frontVertex.navn + " pris: " + frontVertex.lengthFromStartVertex);
                    By holder = frontVertex;
                    while (!holder.navn.Equals(navnPaaStartVertex))
                    {
                        Console.WriteLine("backtracking: " + holder.navn);
                        holder = holder.previousVertex;
                    }
                    Console.WriteLine("backtracking: " + navnPaaStartVertex);
                    search = false;
                    break;
                }
                //--------------------------------------
                foreach (Rute e in frontVertex.ruteliste) //flyt børnene, hvis de er mindre og ikke er visited.
                {
                    // lidt indviklet: Først må vi tjekke for at vertexen ikke allerede er
                    // besøgt. Det er den første if sætning. Siden må vi tjekke om vægten
                    // således at vi ikke overskriver en By som allerede er i køen, og
                    // som har en mindre vægt. Har den mindre vægt, så skal den nye ikke med
                    // i køen. Men om den ny nu har mindre vægt end en som allerede er i køen,
                    // så overskriver vi denne, i stedet for at lave en ny reference, det er if else
                    // sætningen.
                    int w = (int)e.pris;
                    if (e.By.visited == false) //Den er ikke besøgt før, så skal den med.
                    {
                        Boolean laengdeOK = true;
                        Boolean mindreOK = false;
                        foreach (By v in priorityQueue)// Hvis længden er større på den ny, skal
                        { // den heller ikke med her.
                            if (v.navn.Equals(e.By.navn)) //skal først finde samme By navn
                            {
                                if (frontVertex.lengthFromStartVertex + w >= v.lengthFromStartVertex) //hvis length og w er større end den var tidligere, altså en vej der er mindre fra start til barnet.
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
                            e.By.lengthFromStartVertex = frontVertex.lengthFromStartVertex + w;
                            e.By.previousVertex = frontVertex;
                            priorityQueue.Add(e.By);
                            Console.WriteLine(" -> Enqueing: " + e.By.navn + " pris: " + e.By.lengthFromStartVertex + " Previous By: " + e.By.previousVertex.navn + " Queue size:" + priorityQueue.Count);
                        }
                        else if (laengdeOK == true && mindreOK == true)// Så er By´en allered i Køen, Så overskriver vi bare, //OVERSKRIV
                        { // i stedet for at lægge endnu en reference af samme objekt i køen.
                            By v = getVertex(e.By.navn);
                            v.lengthFromStartVertex = frontVertex.lengthFromStartVertex + w;
                            v.previousVertex = frontVertex;
                            Console.WriteLine(" * Overskriver By " + e.By.navn + " pris: " + e.By.lengthFromStartVertex);
                        }
                        else if (laengdeOK == false && mindreOK == false) // findes allerede og har den mindste vægt /DONT ADD 
                        {
                            Console.WriteLine(" * Findes allerede og har mindre eller samme vægt: " + e.By.navn);
                        }
                    }
                    else
                    {
                        Console.WriteLine(" * Besøgt By før: " + e.By.navn);
                    }
                }
            }
        }

        public void FjernForbindelse(string a, string b)
        {
            // metoden skal fjerne noget uanset hvad!

          
                foreach (By by in byliste)
                {
                    if (by.navn.Equals(a))
                    {
                        foreach (Rute rut in by.ruteliste)
                        {
                            if (rut.By.navn.Equals(b))
                            {
                                by.ruteliste.Remove(rut);
                                count2++;
                                return;
                            }
                        }
                    }
                }
            
            

            if (count2 == byliste.Count * (byliste.Count - 1))
            {
                Console.WriteLine("Der er ikke flere forbindelser..");
            }

 
        }

        public void udskrivForbindelser()
        {
            foreach (By b in byliste)
            {
                foreach (Rute forbindelse in b.ruteliste)
                {
                    if (forbindelse != null)
                    {
                        count++;
                        Console.WriteLine(b.navn + " " + forbindelse.By.navn + " " + forbindelse.pris);
                    }
                }
            }
        }

        public void SetAfbudsPris(int min, int max)
        {

            int afbudspris = random.Next(min, max);
            int c = random.Next(0, byliste.Count);
            int d = random.Next(0, byliste.Count);
            int a = random.Next(0, byliste.Count);
            int b = random.Next(0, byliste.Count);
            bool exist = false;

             while (c == d)
             {
                 c = random.Next(0, byliste.Count);
                 d = random.Next(0, byliste.Count);
             }

            FjernForbindelse(byliste[c].navn, byliste[d].navn);


            // sætter afbudspris.

            while (exist == false)
            {

                if (byliste[a].ruteliste[b] != null)
                {
                    byliste[a].ruteliste[b].pris = afbudspris;
                    Console.WriteLine("Prisen mellem " + byliste[a].navn + " og " + byliste[a].ruteliste[b].By.navn + " er nu " + afbudspris);
                    exist = true;
                }
                else if (count == byliste.Count * (byliste.Count - 1))
                {
                    Console.WriteLine("Der er desværre ikke flere rejser...");
                    exist = true;
                }
                else
                {
                    a = random.Next(0, byliste.Count);
                    b = random.Next(0, byliste.Count);

                    while (a == b)
                    {
                        a = random.Next(0, byliste.Count);
                        b = random.Next(0, byliste.Count);
                    }

                }

            }
            count++; // counter fordi der er blevet fjernet 1 forbindelse og sat en afbudsrejse på 1 forbindelse

            exist = false;


        }



        public By findTheVertexWithMostEdges()
        {
            int flestvertex = 0;
            By vert = null;



            foreach (By v in byliste)
            {
                if (v.ruteliste.Count > flestvertex)
                {
                    flestvertex = v.ruteliste.Count;
                    vert = v;

                }
            }


            return vert;
        }
        public void findShortesPathUnweightedGraph(String navnPaaStartVertex)
        {
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getVertex(navnPaaStartVertex);
            startVertex.visited = true;
            startVertex.lengthFromStartVertex = 0;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                frontVertex = vertexQueue.Dequeue();
                foreach (Rute e in frontVertex.ruteliste)
                {
                    if (e.By.visited == false)
                    {
                        e.By.visited = true;
                        e.By.lengthFromStartVertex = frontVertex.lengthFromStartVertex + 1;
                        e.By.previousVertex = frontVertex;
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                    }
                }
            }
            Console.WriteLine("-------- Shortes Path in an Unweighted Graph-------------");
            Console.WriteLine("-------- From By: " + navnPaaStartVertex + " to all other rechable By-------");
            foreach (By v in traversalOrder)
            {
                Console.Write("Name: " + v.navn + " Distance: " + v.lengthFromStartVertex + " - ");
            }
            Console.WriteLine();
        }
        public Boolean isThereAConnection(String a, String b)
        {
            Boolean fundet = false;
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getVertex(a);
            startVertex.visited = true;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                frontVertex = vertexQueue.Dequeue();
                foreach (Rute e in frontVertex.ruteliste)
                {
                    if (e.By.visited == false)
                    {
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.visited = true;
                        if (e.By.navn.Equals(b))
                        {
                            fundet = true;
                        }
                    }
                }
            }
            return fundet;
        }
        public By getVertex(String navn)
        {
            By gemmer = null;
            foreach (By By in byliste)
            {
                if (By.navn.Equals(navn))
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
                v.visited = false;
            }
        }
        public void printGraph()
        {
            foreach (By v in byliste)
            {
                foreach (Rute e in v.ruteliste)
                {
                    Console.WriteLine("From: " + v.navn + " To: " + e.By.navn + " pris: " + e.pris);
                }
            }
        }
        public void BreathFirstTraversal(String navnPaaStartVertex)
        {
            Queue<By> vertexQueue = new Queue<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getVertex(navnPaaStartVertex);
            startVertex.visited = true;
            vertexQueue.Enqueue(startVertex);
            traversalOrder.Enqueue(startVertex);
            By frontVertex;
            while (vertexQueue.Count > 0)
            {
                Console.WriteLine("Items in Queue: " + vertexQueue.Count);
                frontVertex = vertexQueue.Dequeue();
                Console.WriteLine(" <- Dequeue: " + frontVertex.navn + " frontVertex");
                foreach (Rute e in frontVertex.ruteliste)
                {
                    if (e.By.visited == false)
                    {
                        Console.WriteLine(" -> Enqueue: " + e.By.navn);
                        vertexQueue.Enqueue(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.visited = true;
                    }
                }
            }
            Console.Write(" Traversal order: ");
            foreach (By v in traversalOrder)
            {
                Console.Write(v.navn + " ");
            }
            Console.WriteLine();
        }
        public void DepthFirstTraversal(String navnPaaStartVertex)
        {
            Stack<By> vertexStack = new Stack<By>();
            Queue<By> traversalOrder = new Queue<By>();
            By startVertex = getVertex(navnPaaStartVertex);
            startVertex.visited = true;
            By topVertex;
            vertexStack.Push(startVertex);
            traversalOrder.Enqueue(startVertex);
            while (vertexStack.Count > 0)
            {
                Console.WriteLine("Items in Stack: " + vertexStack.Count);
                topVertex = vertexStack.Pop();
                Console.WriteLine(" <- Pop from stack: " + topVertex.navn + " topVertex");
                foreach (Rute e in topVertex.ruteliste)
                {
                    if (e.By.visited == false)
                    {
                        Console.WriteLine(" -> Push to stack: " + e.By.navn);
                        vertexStack.Push(e.By);
                        traversalOrder.Enqueue(e.By);
                        e.By.visited = true;
                    }
                }
            }
            Console.Write(" Traversal order: ");
            foreach (By v in traversalOrder)
            {
                Console.Write(v.navn + " ");
            }
            Console.WriteLine();
        }

    }
    class By
    {
        public String navn;
        public List<Rute> ruteliste = new List<Rute>();
        public Boolean visited = false;
        public int lengthFromStartVertex = 0;
        public By previousVertex = null;
        public By(String n)
        {
            navn = n;
        }
    }
    class Rute
    {
        public By By;
        public double pris;
    }

}
