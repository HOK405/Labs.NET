using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5
{
     class Program
    {
        interface IStructure
        {
            void Connect(Cable cable);
            void Connect(Server server);
            void Connect(Workstation workstation);
        }

        interface INetwork
        {
            void Accept(IStructure s);
        };

        class Cable : INetwork
        {
            public void Accept(IStructure s) => s.Connect(this);
        }

        class Server : INetwork
        {
            public void Accept(IStructure s) => s.Connect(this);
        }
        class Workstation : INetwork
        {
            public void Accept(IStructure s) => s.Connect(this);
        }

        class NetStructure: IStructure
        {
            public int estimation = 0;
            public string result;
            public void Connect(Cable c)
            {
                result = "Cable is connected!";
                estimation += 10;
            }
            public void Connect(Server c)
            {
                result = "Server is provided!";
                estimation += 50;
            }
            public void Connect(Workstation c)
            {
                result = "Workstation is configured!";
                estimation += 100;
            }
        }

        static void Main(string[] args)
        {
            List<INetwork> network = new List<INetwork>() {new Cable(), new Server(), new Workstation(), new Cable(), new Workstation() };
            NetStructure set = new NetStructure();
            foreach (INetwork x in network)
            {
                x.Accept(set);
                Console.WriteLine(set.result);
            }
            Console.WriteLine("\nStructure estimation: " + set.estimation+"$");
            Console.ReadLine();
        }
    }
}
