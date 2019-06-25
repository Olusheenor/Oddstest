using OddsCore;
using System;
using System.Collections.Generic;

namespace OddServices
{
    public class OddsService : IOddService
    {
        public bool AddOdd(Odds input)
        {
            throw new NotImplementedException();
        }

        public List<Odds> GetAll()
        {
            return new List<Odds>()
            {
                new Odds()
                {
                    OddName = "First Odd",
                    OddValue = "2.1"
                },
                 new Odds()
                {
                      OddName = "Second Odd",
                    OddValue = "3.1"
                },
                  new Odds()
                {
                       OddName = "Third Odd",
                    OddValue = "4.1"
                }
            };
        }

        public bool RemoveOdd(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
