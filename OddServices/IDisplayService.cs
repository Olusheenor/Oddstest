using OddsCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OddServices
{
    public interface IDisplayService
    {
        void ShowOdds(List<Odds> odds, string username);
    }
}
