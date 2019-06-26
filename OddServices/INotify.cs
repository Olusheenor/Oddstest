using OddsCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OddServices
{
    interface INotify
    {
        void Update(List<Odds> odds);
    }
}
