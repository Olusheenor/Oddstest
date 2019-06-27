
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using OddsCore;

namespace OddServices
{
    public class User : IUser, INotify
    {
        private IDisplayService _display;
        
        public User()
        {

        }
        public User(IDisplayService display)
        {
            _display = display;
            
        }
        public string UserName { get; set; }
       
        public string ConnectionId { get; set; }
        

        public void Update(List<Odds> odds,IHubContext<MyHub> hubContext)
        {
            // notify the connection of the user... _hub
            hubContext.Clients.Client(this.ConnectionId).SendAsync("LoadOdds", "client", JsonConvert.SerializeObject(odds));

        }
    }
}
