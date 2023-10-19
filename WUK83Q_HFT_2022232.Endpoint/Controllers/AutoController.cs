using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using WUK83Q_HFT_2022232.Endpoint.Services;
using WUK83Q_HFT_2022232.Logic;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {

        IAutoLogic logic;
        IHubContext<SignalRHub> hub;

        public AutoController(IAutoLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Auto> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Auto Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Auto value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("AutoCreated", value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Auto value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AutoUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var autoToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AutoDeleted", autoToDelete);
        }

        [HttpGet("average")]
        public double? AverageVintage()
        {
            return this.logic.AverageVintage();
        }


        [HttpGet("youngorold")]
        public Auto YoungestOrOldestCar([FromQuery]char YoungOrOld)
        {
            return this.logic.YoungestOrOldestCar(YoungOrOld);
        }
    }
}
