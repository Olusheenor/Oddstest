using System;
using System.Collections.Generic;
using System.Text;
using OddsCore;

namespace OddServices
{
    public class DisplayService : IDisplayService
    {
        public void ShowOdds(List<Odds> allOdds, string username = null)
        {
            //show the user the list of all odds..

            int counter = 0;

            foreach (var odd in allOdds)
            {
                counter++;

                if (username == "admin")
                {
                    Console.WriteLine($"{counter}. Name : {odd.OddName} | Value : {odd.OddValue} | Published: {(odd.IsPublished ? "Yes" : "No")}");
                }
                else
                {
                    Console.WriteLine($"{counter}. Name : {odd.OddName} | Value : {odd.OddValue}");
                }
            }
        }
    }
}