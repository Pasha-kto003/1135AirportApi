using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1135AirportApi.db;
using ModelsApi;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1135AirportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly _1135_airportContext dbContext;

        public CityController(_1135_airportContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<CityApi> Get()
        {
            return dbContext.Cities.ToList().Select(s => {
                var transfers = dbContext.Airports.Where(t => t.IdCity == s.Id).Select(t => (AirportApi)t).ToList();
                return CreateCityApi(s, transfers);
            });
        }
        private CityApi CreateCityApi(City s, List<AirportApi> airports)
        {
            var result = (CityApi)s;
            result.Airports = airports;
            return result;
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityApi>> Get(int id)
        {
            var city = await dbContext.Cities.FindAsync(id);
            if (city == null)
                return NotFound();
            var transfers = dbContext.Airports.Where(t => t.IdCity == id).Select(t => (AirportApi)t).ToList();
            return Ok(CreateCityApi(city, transfers));
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CityApi newCityApi)
        {
            var newCity = (City)newCityApi;
            await dbContext.Cities.AddAsync(newCity);
            await dbContext.SaveChangesAsync();
            var airports = newCityApi.Airports.Select(s => (Airport)s);
            foreach (var t in airports)
                t.IdCity = newCity.Id;
            await dbContext.Airports.AddRangeAsync(airports);
            await dbContext.SaveChangesAsync();
            return Ok(newCity.Id);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CityApi editCity)
        {
            var city = await dbContext.Cities.FindAsync(id);
            if (city == null)
                return NotFound();
            dbContext.Entry(city).CurrentValues.SetValues(editCity);
            var airports = dbContext.Airports.ToList();
            dbContext.Airports.RemoveRange(airports);
            var reairports = editCity.Airports.Select(s => (Airport)s);
            foreach (var t in reairports)
                t.IdCity = editCity.Id;
            await dbContext.Airports.AddRangeAsync(reairports);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldCity = await dbContext.Cities.FindAsync(id);
            if (oldCity == null)
                return NotFound();
            var airports = dbContext.Airports.ToList();
            dbContext.Airports.RemoveRange(airports);
            dbContext.Cities.Remove(oldCity);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
