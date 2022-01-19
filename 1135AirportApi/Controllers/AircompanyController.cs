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
    public class AircompanyController : ControllerBase
    {
        private readonly _1135_airportContext dbContext;

        public AircompanyController(_1135_airportContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<AircompanyController>
        [HttpGet]
        public IEnumerable<AircompanyApi> Get()
        {
            return dbContext.Aircompanies.Select(s => (AircompanyApi)s);
        }

        // GET api/<AircompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircompanyApi>> Get(int id)
        {
            var company = await dbContext.Aircompanies.FindAsync(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        // POST api/<AircompanyController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AircompanyApi value)
        {
            var newCompany = (Aircompany)value;
            dbContext.Aircompanies.Add(newCompany);
            await dbContext.SaveChangesAsync();
            return Ok(newCompany.Id);
        }

        // PUT api/<AircompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AircompanyApi value)
        {
            var oldCompany = await dbContext.Aircompanies.FindAsync(id);
            if (oldCompany == null)
                return NotFound();
            dbContext.Entry(oldCompany).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<AircompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldCompany = await dbContext.Aircompanies.FindAsync(id);
            if (oldCompany == null)
                return NotFound();
            dbContext.Aircompanies.Remove(oldCompany);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
