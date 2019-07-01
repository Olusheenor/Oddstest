
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
        private IHubContext<MyHub> _hubContext;
        public User()
        {

        }
        public User(IDisplayService display, IHubContext<MyHub> hubContext)
        {
            _display = display;
            _hubContext = hubContext;
            
        }
        public string UserName { get; set; }
       
        public string ConnectionId { get; set; }
        

        public void Update(List<Odds> odds)
        {
            //app.ApplicationServices.GetRequiredService<IHubContext<UserInterfaceHub>>();
            // notify the connection of the user... _hub
            _hubContext.Clients.Client(this.ConnectionId).SendAsync("LoadOdds", "client", JsonConvert.SerializeObject(odds));

        }
    }
}
