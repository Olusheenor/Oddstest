using OddsCore;
using OddServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OddsServer
{
    public class OddServiceAdmin : IOddService
    {
        private readonly string baseUrl = "http://localhost:52271";

        public void Add(Odds input)
        {

            throw new NotImplementedException();
        }

        public List<Odds> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Publish()
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Odds input)
        {
            throw new NotImplementedException();
        }
    }
}
