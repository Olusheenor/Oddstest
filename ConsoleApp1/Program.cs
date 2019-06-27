using System;
using Microsoft.Owin;
using OddsServer;
using OddServices;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

[assembly: OwinStartup(typeof(Startup))]
namespace OddsServer
{
    class Program
    {
        private static IDisposable SignalR;
        static void Main(string[] args)
        {

            BuildWebHost(args).Start();

            //setup our DI
            //Usually we can use a registration by convention but for simplicity sake lets just simulate
            var serviceProvider = new ServiceCollection()
                
                .AddSingleton<IDisplayService, DisplayService>()
                .AddSingleton<IUser, User>()
                .AddSingleton<IOddService, OddsService>()
                .AddTransient<MyHub>()
                .BuildServiceProvider();

            Console.WriteLine("Hello there! Welcome to OddestOdds.com");


            //injecting an instance of odd service earlier set up
            var _displayService = serviceProvider.GetService<IDisplayService>();
            var _oddService = serviceProvider.GetService<IOddService>();
            //var _oddServicePub = serviceProvider.GetService<I>();
           

            

            Console.WriteLine("You are an admin user.. Please manage your odds here");

            Console.WriteLine("Loading the list of all Odds...");
            Thread.Sleep(2000);


            var allOdds = _oddService.GetAll();

            _displayService.ShowOdds(allOdds, "admin");

            Console.WriteLine();
            Console.WriteLine($"Enter Add, Del, Pub to Add, Delete or Publish Odds");

            while(true)
            {
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
                        _displayService.ShowOdds(savedOdds, "admin");
                        break;
                    case "del":
                        Console.WriteLine("Enter the name of the odd to delete...");
                        var delOdd = Console.ReadLine();
                        _oddService.Remove(delOdd);
                        var odds = _oddService.GetAll();
                        _displayService.ShowOdds(odds, "admin");
                        break;
                    case "pub":
                        _oddService.Publish();
                        break;

                    default:
                          
                        break;
                }
            }
            





        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:55830")
               .UseStartup<Startup>()
               .Build();
    }

    


  
}
