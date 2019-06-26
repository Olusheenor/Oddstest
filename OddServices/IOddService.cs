using OddsCore;
using System.Collections.Generic;

namespace OddServices
{
    public interface IOddService
    {
        //Crud Methods
        List<Odds> GetAll();
        void Add(Odds input);
        void Remove(string name);

        void Update(Odds input);

        // Observer pattern Methods
        void Publish();
        void Subscribe(User user);
    }
}