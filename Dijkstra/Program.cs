using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        Vertex<City>[] graph;
        IDictionary<Edge<City>, int> distances = new Dictionary<Edge<City>, int>();

        Vertex<City> nairobi;
        Vertex<City> nakuru;
        Vertex<City> mombasa;
        Vertex<City> kakamega;
        Vertex<City> machakos;
        Vertex<City> thika;
        Vertex<City> ruiru;
        Vertex<City> eldoret;
        public Program()
        {
            graph = new Vertex<City>[6];
            nairobi = new Vertex<City>(new City("Nairobi"));
            nakuru = new Vertex<City>(new City("Nakuru"));
            mombasa = new Vertex<City>(new City("Mombasa"));
            kakamega = new Vertex<City>(new City("Kakamega"));
            machakos = new Vertex<City>(new City("Machakos"));
            thika = new Vertex<City>(new City("Thika"));
            ruiru = new Vertex<City>(new City("Ruiru"));
            eldoret = new Vertex<City>(new City("Eldoret"));

            nairobi.AddNeighbour(new Edge<City>(nairobi, mombasa));
            distances.Add(new Edge<City>(nairobi, mombasa), 400);
            nairobi.AddNeighbour(new Edge<City>(nairobi, nakuru));
            distances.Add(new Edge<City>(nairobi, nakuru), 200);
            nairobi.AddNeighbour(new Edge<City>(nairobi, machakos));
            distances.Add(new Edge<City>(nairobi, machakos), 50);
            nakuru.AddNeighbour(new Edge<City>(nakuru, kakamega));
            distances.Add(new Edge<City>(nakuru, kakamega), 200);
            nakuru.AddNeighbour(new Edge<City>(nakuru, eldoret));
            distances.Add(new Edge<City>(nakuru, eldoret), 200);
            eldoret.AddNeighbour(new Edge<City>(eldoret, kakamega));
            distances.Add(new Edge<City>(eldoret, kakamega), 50);

            graph[0] = nairobi;
            graph[1] = mombasa;
            graph[2] = nakuru;
            graph[3] = machakos;
            graph[4] = kakamega;
            graph[5] = eldoret;

            

        }

        public void Dijkstra(Vertex<City>[] G, int startcity)
        {
            int i; //counter
            bool[] intree = new bool[20]; //is vertex in tree yt?
            int[] distance = new int[20]; //distnce of vertext from start

        }
        static void Main(string[] args)
        {
        }
    }

    public class Vertex<T>
    {

        private T _data;
        private LinkedList<Edge<T>> _neighbours;
        private bool _discovered = false;
        private bool _processed = false;
        private Vertex<T> _parent;

        public Vertex(T data)
        {
            _data = data;
            _neighbours = new LinkedList<Edge<T>>();
        }
        public T Data
        {
            get
            {
                return _data;
            }
        }

        public LinkedList<Edge<T>> Neighbours
        {
            get { return _neighbours; }
            set
            {
                _neighbours = value;
            }
        }

        public bool Discovered
        {
            get { return _discovered; }
            set
            {
                _discovered = value;
            }
        }

        public bool Processed
        {
            get { return _processed; }
            set
            {
                if (_processed == true)
                {
                    throw new Exception("Vertex has already been processed");
                }
                else
                {
                    _processed = value;
                }
            }
        }

        public Vertex<T> Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                {
                    throw new Exception("Vertex already has a parent");
                }
                else
                {
                    _parent = value;
                }
            }
        }

        public void AddNeighbour(Edge<T> value)
        {
            Neighbours.AddLast(value);
            if (((from n in value.Node2.Neighbours
                 where n.Node1 == value.Node2 && n.Node2 == value.Node1
                 select n).Count() == 0))
            {
                value.Node2.Neighbours.AddLast(new Edge<T>(value.Node2, value.Node1));
            }
        }
    }

    public class Edge<T>
    {
        public Edge(Vertex<T> node1, Vertex<T> node2)
        {
            this.node1 = node1;
            this.node2 = node2;
            //this.weight = weight;
        }
        public Vertex<T> node1;
        public Vertex<T> node2;
        //public int weight;

        public Vertex<T> Node1
        {
            get { return node1; }
        }

        public Vertex<T> Node2
        {
            get { return node2; }
        }

        
    }

    public class City
    {
        string name;
        public City(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
        public override string ToString()
        {
            return name;
        }
    }
}
