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
        [Route("GetOdds")]
        public ActionResult<IEnumerable<string>> Get()
        {
            _hubContext.Clients.All.SendAsync("LoadOdds", JsonConvert.SerializeObject(_oddService.GetAll()));
            return Ok();
        }

        // GET api/values/5
        [HttpPost]
        [Route("AddOdds")]
        public ActionResult<string> Add([FromBody]Odds odd)
        {
            _oddService.Add(odd);
            return Ok();

        }

        // POST api/values
        [HttpPost]
        [Route("RemoveOdd")]
        public void Post([FromBody] string OddName)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
