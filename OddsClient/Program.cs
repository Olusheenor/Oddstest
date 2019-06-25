using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using OddServices;

namespace OddsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOddService, OddsService>()
                .BuildServiceProvider();

            Console.WriteLine("Hello there! Welcome to OddestOdds.com");

            Console.WriteLine("Enter your username to proceed:");

            string name = Console.ReadLine();

            if (name.ToLower() == "admin")
            {
                Console.WriteLine("Showing you list of all Odds...");

                Thread.Sleep(3000);

                var oddService = serviceProvider.GetService<IOddService>();

                var allOdds = oddService.GetAll();

                int counter = 0;
                foreach(var odd in allOdds)
                {
                    counter++;
                    Console.WriteLine($"{counter}. Name : {odd.OddName} : Value : {odd.OddValue} Published: {(odd.IsPublished ? "Yes":"No")}");
                }

                Console.WriteLine($"{allOdds.Count} Odds found...");
                Console.WriteLine($"Enter Add, Del, Pub to Add, Delete or Publish Odds");

                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "add":
                         Console.WriteLine("You selected add");
                             break;
                    default:
                        break;
                }
                
            }
            {

            }

            Console.ReadKey();
        }
    }
}
