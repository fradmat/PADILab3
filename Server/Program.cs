using CommonInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSide serverSide = new ServerSide();
            serverSide.RegisterServer();
            System.Console.WriteLine("<enter> para sair...");
            System.Console.ReadLine();
        }
    }
}
