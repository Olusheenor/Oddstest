using OddsCore;
using OddServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OddsServer
{
    public class OddServiceAdmin : IOddService
    {
        private readonly string baseUrl = "http://localhost:52271/api/odds/";

        public void Add(Odds input)
        {

            string url = baseUrl + "Add";
            var x =  RestUtility.CallServiceAsync<string>(url, input, "POST").Result;

        }

        public List<Odds> GetAll()
        {
            string url = baseUrl + "LoadOdds";
            var x = RestUtility.CallServiceAsync<List<Odds>>(url, null, "GET").Result as List<Odds>;
            return x;
        }

        public void Publish()
        {
            string url = baseUrl + "Publish";
            var x = RestUtility.CallServiceAsync<List<Odds>>(url, null, "GET").Result as List<Odds>;
            
        }

        public void Remove(string name)
        {
            string url = baseUrl + "Remove";
            var x = RestUtility.CallServiceAsync<List<Odds>>(url, name, "POST").Result as List<Odds>;
        }

        public void Subscribe(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Odds input)
        {
            string url = baseUrl + "Update";
            var x =  RestUtility.CallServiceAsync<string>(url, input, "POST").Result;

        }
    }
}
