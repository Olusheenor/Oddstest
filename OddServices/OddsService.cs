using OddsCore;
using System;
using System.Collections.Generic;

namespace OddServices
{
    public class OddsService : IOddService
    {
        private static List<Odds> _listOdds = new List<Odds>();
        private static HashSet<User> _subScribedUsers = new HashSet<User>();
        public OddsService()
        {
            _listOdds = new List<Odds>()
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
        public void Add(Odds input)
        {
            _listOdds.Add(input);
           
        }

        public void Update(Odds input)
        {
            _listOdds.RemoveAll(d=>d.OddName == input.OddName);

            _listOdds.Add(input);

        }

        public List<Odds> GetAll()
        {
            return _listOdds;
        }

        public void Remove(string name)
        {
            _listOdds.RemoveAll(s => s.OddName == name);

        }

        public void Subscribe(User user)
        {
            if (!_subScribedUsers.Contains(user))
            {
                _subScribedUsers.Add(user);
            }
            
        }
      
        public void Publish()
        {
            foreach (var item in _listOdds)
            {
                item.IsPublished = true;
            }

            // Real time notify all users of new odds!!

            foreach(var user in _subScribedUsers)
            {
                user.Update(_listOdds);
            }
        }
    }
}
