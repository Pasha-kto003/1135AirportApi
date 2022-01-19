using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1135AirportApi.db;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1135AirportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly _1135_airportContext db;

        public ClientController(_1135_airportContext db)
        {
            this.db = db;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<ClientApi> Get()
        {
            return db.Clients.ToList().Select(s => {
                var passport = db.Passports.FirstOrDefault(p => p.Id == s.IdPassport);
                return CreateClientApi(s, passport);
                });
        }

        private ClientApi CreateClientApi(Client client, Passport passport)
        {
            var clientApi = (ClientApi)client;
            clientApi.Passport = (PassportApi)passport;
            return clientApi;
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientApi>> Get(int id)
        {
            var client = await db.Clients.FindAsync(id);
            var passport = await db.Passports.FindAsync(client.IdPassport);
            return CreateClientApi(client, passport);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ClientApi client)
        {
            Passport passport = (Passport)client.Passport;
            await db.Passports.AddAsync(passport);
            await db.SaveChangesAsync();
            Client newClient = (Client)client;
            newClient.IdPassport = passport.Id;
            await db.Clients.AddAsync(newClient);
            await db.SaveChangesAsync();
            return Ok(newClient.Id);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientApi clientEdit)
        {
            var client = await db.Clients.FindAsync(id);
            if (client == null)
                return NotFound();
            Passport passport = (Passport)clientEdit.Passport;
            if (passport.Id == 0)
                return BadRequest("Неверный паспорт");
            Client newClient = (Client)clientEdit;
            db.Entry(client).CurrentValues.SetValues(newClient);
            client.IdPassportNavigation = passport;
            await db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await db.Clients.FindAsync(id);
            if (client == null)
                return NotFound();
            db.Remove(client);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
