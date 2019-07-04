using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OddServices;
using System.Linq;

namespace Tests
{
    public class OddServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_If_Odds_Add()
        {
            var Odds = new OddsCore.Odds()
            {
                OddName = "Test",
                IsPublished = false,
                OddValue = "1.1"
            };

            var serviceProvider = new ServiceCollection().AddSingleton<IOddService, OddsService>().
                BuildServiceProvider();

            var oddService = serviceProvider.GetService<IOddService>();

            oddService.Add(Odds);

            var exist = oddService.GetAll().Any(o => o.OddName == "Test");

            Assert.AreEqual(true, exist);
        }
    }
}