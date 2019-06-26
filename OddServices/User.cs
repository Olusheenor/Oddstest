
using System;
using System.Collections.Generic;
using System.Text;
using OddsCore;

namespace OddServices
{
    public class User : IUser, INotify
    {
        private IDisplayService _display;
        public User(IDisplayService display)
        {
            _display = display;
        }
        public string UserName { get; set; }
       
        

        public void Update(List<Odds> odds)
        {
            _display.ShowOdds(odds, this.UserName);
        }
    }
}
