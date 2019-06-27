using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddServices
{
    public class MyHub : Hub
    {
        IOddService _oddService;
        IDisplayService _displayService;
        public MyHub(IOddService oddService, IDisplayService displayService)
        {
            _oddService = oddService;
            _displayService = displayService;
        }

        public override async Task OnConnectedAsync()
        {
            
            _oddService.Subscribe(new User() { UserName = "client", ConnectionId = Context.ConnectionId });
             await base.OnConnectedAsync();
        }

        public void LoadOdds()
        {

           var x = _oddService.GetAll().Where(s => s.IsPublished).ToList();
           
            Clients.Client(Context.ConnectionId).SendAsync("LoadOdds", "client", JsonConvert.SerializeObject(x));
        }

        public void NotifyNewOdds(string connectionId)
        {

            if (string.IsNullOrEmpty(connectionId))
            {
                connectionId = Context.ConnectionId;
            }
            var x = _oddService.GetAll().Where(s => s.IsPublished).ToList();
            
            Clients.Client(connectionId).SendAsync("LoadOdds", "client", JsonConvert.SerializeObject(x));
        }
    }
}
