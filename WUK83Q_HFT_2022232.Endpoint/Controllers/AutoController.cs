using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WUK83Q_HFT_2022232.Logic;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {

        IAutoLogic logic;

        public AutoController(IAutoLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Auto value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("average")]
        public double? AverageVintage()
        {
            return this.logic.AverageVintage();
        }

        [HttpGet("{id}")]
        public void CarOwnedByOwner(int id)
        {
            this.logic.CarOwnedByOwner(id);
        }

        [HttpGet("YoungOrOld")]
        public Auto YoungestOrOldestCar(char YoungOrOld)
        {
            return this.logic.YoungestOrOldestCar(YoungOrOld);
        }
    }
}
