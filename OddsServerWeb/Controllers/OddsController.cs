using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using OddServices;
using Newtonsoft.Json;
using OddsCore;

namespace OddsServerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsController : ControllerBase
    {
        IHubContext<MyHub> _hubContext;
        IOddService _oddService;
        public OddsController(IHubContext<MyHub> hubContext, IOddService oddService)
        {
            _hubContext = hubContext;
            _oddService = oddService;
        }
        // GET api/values
        [HttpGet]
        [Route("LoadOdds")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var odds = _oddService.GetAll();
            return Ok(odds);
        }

        // GET api/values/5
        [HttpPost]
        [Route("AddOdd")]
        public ActionResult Add([FromBody]Odds odd)
        {
            _oddService.Add(odd);
            return Ok();

        }

        [HttpPost]
        [Route("RemoveOdd")]
        public ActionResult Post([FromBody] string OddName)
        {
            _oddService.Remove(OddName);
            return Ok();
        }


        [HttpGet]
        [Route("Publish")]
        public void Publish()
        {
            _oddService.Publish();


            //_hubContext.Clients.All.SendAsync("LoadOdds", JsonConvert.SerializeObject(_oddService.GetAll()));
            
        }

     
    }
}
