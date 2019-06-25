using OddsCore;
using System.Collections.Generic;

namespace OddServices
{
    public interface IOddService
    {
        List<Odds> GetAll();
        bool AddOdd(Odds input);
        bool RemoveOdd(int Id);
    }
}