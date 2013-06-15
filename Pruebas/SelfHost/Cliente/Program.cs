using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cliente.ServiceReference1;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {

            HelloWorldServiceClient client = new HelloWorldServiceClient();
            Console.WriteLine(client.SayHello("don fernando"));
            client.Close();
            Console.ReadLine();

        }
    }
}
