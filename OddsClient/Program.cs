using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OddsCore;
using OddServices;

namespace OddsClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            HubConnection connection = new HubConnectionBuilder()
              .WithUrl("http://localhost:52271/notifications")
              .Build();


            //setup our DI
            //Usually we can use a registration by convention but for simplicity sake lets just simulate
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDisplayService, DisplayService>()
                .BuildServiceProvider();

            Console.WriteLine("Hello there! Welcome to OddestOdds.com");

    
            var _displayService = serviceProvider.GetService<IDisplayService>();



            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            List<Odds> odds = new List<Odds>();

            connection.On<string, string>("LoadOdds", (s1, s2) =>
            {
               
                odds = JsonConvert.DeserializeObject<List<Odds>>(s2);
                _displayService.ShowOdds(odds);

                Console.WriteLine($"Last Refresh time : {DateTime.Now.ToString("dd,MM,yyyy :hh:mm:ss tt")}");
            });

            await connection.StartAsync();

            bool connected = (connection.State == HubConnectionState.Connected);

            if(connected)
            {
                Console.WriteLine("Connected to oddestodds server.......");

                await connection.InvokeAsync("LoadOdds");
                
                Console.ReadKey(); 
            }
            else
            {
                Console.WriteLine("an error occured while connecting to server");
            }
           
            

            
        }
    }
}
