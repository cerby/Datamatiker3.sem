using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graf = new Graph();
         
            graf.TilføjBy("København");
            graf.TilføjBy("Oslo");
            graf.TilføjBy("Stockholm");
            graf.TilføjBy("Paris");
            graf.TilføjBy("London");
            graf.TilføjBy("Dublin");
            graf.TilføjBy("Rom");
            graf.TilføjBy("Berlin");

            graf.TilføjForbindelse("København", "Oslo", 2);
            graf.TilføjForbindelse("København", "Paris", 5);
            graf.TilføjForbindelse("København", "London", 4);
            graf.TilføjForbindelse("Oslo", "London", 1);
            graf.TilføjForbindelse("Paris", "Rom", 2);
            graf.TilføjForbindelse("London", "Dublin", 3);
            graf.TilføjForbindelse("London", "Berlin", 6);
            graf.TilføjForbindelse("Dublin", "Stockholm", 4);
            graf.TilføjForbindelse("Dublin", "Berlin", 3);
            graf.TilføjForbindelse("Stockholm", "Oslo", 3);
        
        

            Console.WriteLine(graf.findTheVertexWithMostEdges().navn);
            graf.FindBilligsteRute("København", "Rom");


        }
    }
    class Graph
    {
        List<By> grafList = new List<By>();

        public By findTheVertexWithMostEdges()
        {
            int flestvertex = 0;
            By vert = null;



            foreach (By v in grafList)
            {
                if (v.edgeList.Count > flestvertex)
                {
                    flestvertex = v.edgeList.Count;
                    vert = v;

                }
            }


            return vert;
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
                Console.WriteLine(" <- Dequeue: " + frontVertex.navn + " with weight: " + frontVertex.lengthFromStartVertex + " Queue size:" + priorityQueue.Count);
                //----Prioritizing STOP-------------------------------------------
                //-----We have found the By-------------------------------------

                // NU har vi fundet den mindste i grafen


                if (frontVertex.navn.Equals(navnPaaStopVertex)) //hvis vi nu finder den rigtige By så går den herind
                {
                    Console.WriteLine(" ---------- Found: Name: " + frontVertex.navn + " Weight: " + frontVertex.lengthFromStartVertex);
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
                foreach (Forbindelse e in frontVertex.edgeList) //flyt børnene, hvis de er mindre og ikke er visited.
                {
                    // lidt indviklet: Først må vi tjekke for at vertexen ikke allerede er
                    // besøgt. Det er den første if sætning. Siden må vi tjekke om vægten
                    // således at vi ikke overskriver en By som allerede er i køen, og
                    // som har en mindre vægt. Har den mindre vægt, så skal den nye ikke med
                    // i køen. Men om den ny nu har mindre vægt end en som allerede er i køen,
                    // så overskriver vi denne, i stedet for at lave en ny reference, det er if else
                    // sætningen.
                    int w = (int)e.weight;
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
                            Console.WriteLine(" -> Enqueing: " + e.By.navn + " Weight: " + e.By.lengthFromStartVertex + " Previous By: " + e.By.previousVertex.navn + " Queue size:" + priorityQueue.Count);
                        }
                        else if (laengdeOK == true && mindreOK == true)// Så er By´en allered i Køen, Så overskriver vi bare, //OVERSKRIV
                        { // i stedet for at lægge endnu en reference af samme objekt i køen.
                            By v = getVertex(e.By.navn);
                            v.lengthFromStartVertex = frontVertex.lengthFromStartVertex + w;
                            v.previousVertex = frontVertex;
                            Console.WriteLine(" * Overskriver By " + e.By.navn + " Weight: " + e.By.lengthFromStartVertex);
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
                foreach (Forbindelse e in frontVertex.edgeList)
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
                foreach (Forbindelse e in frontVertex.edgeList)
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
        public void TilføjBy(string navn)
        {
            By v = new By(navn);
            grafList.Add(v);
        }
        public void TilføjForbindelse(String VertexBegin, String VertexEnd, double edgeWeight)
        {
            Forbindelse Forbindelse = new Forbindelse();
            Forbindelse.By = getVertex(VertexEnd);
            Forbindelse.weight = edgeWeight;
            getVertex(VertexBegin).edgeList.Add(Forbindelse);
        }
        public By getVertex(String navn)
        {
            By gemmer = null;
            foreach (By By in grafList)
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
            foreach (By v in grafList)
            {
                v.visited = false;
            }
        }
        public void printGraph()
        {
            foreach (By v in grafList)
            {
                foreach (Forbindelse e in v.edgeList)
                {
                    Console.WriteLine("From: " + v.navn + " To: " + e.By.navn + " weight: " + e.weight);
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
                foreach (Forbindelse e in frontVertex.edgeList)
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
                foreach (Forbindelse e in topVertex.edgeList)
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
        public List<Forbindelse> edgeList = new List<Forbindelse>();
        public Boolean visited = false;
        public int lengthFromStartVertex = 0;
        public By previousVertex = null;
        public By(String n)
        {
            navn = n;
        }
    }
    class Forbindelse
    {
        public By By;
        public double weight;
    }



}