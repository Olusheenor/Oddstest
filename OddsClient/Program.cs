using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
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

            var connection = new HubConnection("http://127.0.0.1:8088/");

            var myHub = connection.CreateHubProxy("NotificationsHub");

            bool connected = connection.Start().IsCompletedSuccessfully;

            if(connected)
            {
                Console.WriteLine(connected);
                Console.WriteLine("Connected to oddestodds server.......");

                var user = new User(_displayService) { UserName = "client", ConnectionId = connection.ConnectionId };

                _oddService.Subscribe(user);

                //TODO remove the linq .. make it solid
                var odds = _oddService.GetAll().Where(s => !s.IsPublished).ToList();

                _displayService.ShowOdds(odds, user.UserName);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("an error occured while connecting to server");
            }
           
            

            
        }
    }
}
