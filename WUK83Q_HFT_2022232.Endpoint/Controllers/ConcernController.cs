using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public ConcernController(IConcernLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Concern value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
