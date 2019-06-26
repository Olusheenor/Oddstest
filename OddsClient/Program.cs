using System;
using System.Linq;
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
            //Usually we can use a registration by convention but for simplicity sake lets just simulate
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOddService, OddsService>()
                .AddSingleton<IDisplayService, DisplayService>()
                .AddSingleton<IUser, User>()
                .BuildServiceProvider();

            Console.WriteLine("Hello there! Welcome to OddestOdds.com");

            //injecting an instance of odd service earlier set up
            var _oddService = serviceProvider.GetService<IOddService>();
            var _displayService = serviceProvider.GetService<IDisplayService>();

            while (true)
            {

                Console.WriteLine("Enter your username to proceed:");

                string username = Console.ReadLine();

                // to show admin view..
                if (username.ToLower() == "admin")
                {
                    
                    //new admin user instantiated with an injection of display service
                    var user = new User(_displayService) { UserName = "admin" };

                    //subscribe to updates to changes on odds service..
                    //_oddService.Subscribe(user);

                    Console.WriteLine("Loading the list of all Odds...");

                    Thread.Sleep(2000);


                    var allOdds = _oddService.GetAll();

                    _displayService.ShowOdds(allOdds, username);

                    Console.WriteLine($"{allOdds.Count} Odds found...");
                    Console.WriteLine($"Enter Add, Del, Pub to Add, Delete or Publish Odds");


                    string command = Console.ReadLine();
                    switch (command.ToLower())
                    {
                        case "add":
                            Console.WriteLine("Please enter the odds name and press enter");
                            string oddName = Console.ReadLine();
                            Console.WriteLine("Please enter the odds value and press enter");
                            string oddValue = Console.ReadLine();
                            _oddService.Add(new OddsCore.Odds()
                            {
                                OddName = oddName,
                                OddValue = oddValue,
                                IsPublished = false
                            });

                            Console.WriteLine("You odd has been successfully added.");
                            var savedOdds = _oddService.GetAll();
                            _displayService.ShowOdds(savedOdds, username);
                            break;
                        case "del":
                            Console.WriteLine("Enter the name of the odd to delete...");
                            var delOdd = Console.ReadLine();
                            _oddService.Remove(delOdd);
                            var odds = _oddService.GetAll();
                            _displayService.ShowOdds(odds, username);
                            break;
                        case "pub":
                            _oddService.Publish();
                            break;
                        default:
                            break;
                    }



                }
                
                // to show plunker view..
                else
                {
                    var user = new User(_displayService) { UserName = username };
                    _oddService.Subscribe(user);

                    //TODO remove the linq .. make it solid
                    var odds = _oddService.GetAll().Where(s=> !s.IsPublished).ToList();

                    _displayService.ShowOdds(odds, username);
                }

                Console.ReadKey();
            }

            
        }
    }
}
