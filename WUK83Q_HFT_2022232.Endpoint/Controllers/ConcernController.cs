using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WUK83Q_HFT_2022232.Endpoint.Services;
using WUK83Q_HFT_2022232.Logic;
using WUK83Q_HFT_2022232.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WUK83Q_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConcernController : ControllerBase
    {
        IConcernLogic logic;
        IHubContext<SignalRHub> hub;

        public ConcernController(IConcernLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Concern> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Concern Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Concern value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ConcernCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Concern value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ConcernUpdate", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var concernDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDelete", concernDelete);
        }

        [HttpGet("mostbrandconcern")]
        public string ConcernWithTheMostBrands()
        {
            return this.logic.ConcernWithTheMostBrands();
        }
        [HttpGet("countrysconcern")]
        public List<Concern> ConcernOfOneExactCountry([FromQuery] string countryName)
        {
            return this.logic.ConcernOfOneExactCountry(countryName);
        }
        [HttpGet("concernlist")]
        public string ListOfConcerns()
        {
            return this.logic.ListOfConcerns();
        }
    }
}
