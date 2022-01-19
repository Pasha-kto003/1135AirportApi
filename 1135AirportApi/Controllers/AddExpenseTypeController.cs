using _1135AirportApi.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1135AirportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddExpenseTypeController : ControllerBase
    {
        private readonly _1135_airportContext db;

        public AddExpenseTypeController(_1135_airportContext db)
        {
            this.db = db;
        }
        // GET: api/<AddExpenseTypeController>
        [HttpGet]
        public IEnumerable<AddExpenseTypeApi> Get()
        {
            return db.AddExpenseTypes.Select(s=>(AddExpenseTypeApi)s);
        }

        // GET api/<AddExpenseTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddExpenseTypeApi>> Get(int id)
        {
            var result = await db.AddExpenseTypes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((AddExpenseTypeApi)result);
        }

        // POST api/<AddExpenseTypeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AddExpenseTypeApi value)
        {
            var type = (AddExpenseType)value;
            await db.AddExpenseTypes.AddAsync(type);
            await db.SaveChangesAsync();
            return Ok(type.Id);
        }

        // PUT api/<AddExpenseTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AddExpenseTypeApi value)
        {
            var result = await db.AddExpenseTypes.FindAsync(id);
            if (result == null)
                return NotFound();
            var type = (AddExpenseType)value;
            db.Entry(result).CurrentValues.SetValues(type);
            await db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<AddExpenseTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await db.AddExpenseTypes.FindAsync(id);
            if (client == null)
                return NotFound();
            db.Remove(client);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
