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
    public class BrandController : ControllerBase
    {

        IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandDelete);
        }

        [HttpGet("brandwiththemostcars")]
        public string BrandWithTheMostCars()
        {
            return this.logic.BrandWithTheMostCars();
        }

        [HttpGet("modelsofbrand")]
        public string ModelsOfBrand([FromQuery]string brandName)
        {
            return this.logic.ModelsOfBrand(brandName);
        }

        [HttpGet("brandsofconcern")]
        public List<Brand> GetBrandByName([FromQuery]string concernName)
        {
            return this.logic.GetBrandByName(concernName);
        }
    }
}
