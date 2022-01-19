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
    public class TarifController : ControllerBase
    {
        private readonly _1135_airportContext db;

        public TarifController(_1135_airportContext db)
        {
            this.db = db;
        }
        // GET: api/<TarifController>
        [HttpGet]
        public IEnumerable<TarifApi> Get()
        {
            return db.Tarifs.ToList().Select(s =>
            {
                var types = db.CrossTarifAddExpenses.Where(t => t.IdTarif == s.Id).Select(t=>(AddExpenseTypeApi)t.IdTypeExpenseNavigation).ToList();
                return CreateTarifApi(s, types);
            });
        }

        private TarifApi CreateTarifApi(Tarif tarif, List<AddExpenseTypeApi> types)
        {
            var result = (TarifApi)tarif;
            result.AddExpenseTypes = types;
            return result;
        }

        // GET api/<TarifController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarifApi>> Get(int id)
        {
            var tarif = await db.Tarifs.FindAsync(id);
            var types = db.CrossTarifAddExpenses.Where(t => t.IdTarif == id).Select(t => (AddExpenseTypeApi)t.IdTypeExpenseNavigation).ToList();
            return CreateTarifApi(tarif, types);
        }

        // POST api/<TarifController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TarifApi newTarif)
        {
            foreach (var types in newTarif.AddExpenseTypes)
                if (types.Id == 0)
                    return BadRequest($"Услуга {types.Title} не существует");
            var tarif = (Tarif)newTarif;
            await db.Tarifs.AddAsync(tarif);
            await db.SaveChangesAsync();
            await db.CrossTarifAddExpenses.AddRangeAsync(newTarif.AddExpenseTypes.Select(s=>new CrossTarifAddExpense {
                IdTarif = tarif.Id,
                IdTypeExpense = s.Id
            }));
            await db.SaveChangesAsync();
            return Ok(tarif.Id);
        }

        // PUT api/<TarifController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TarifApi editTarif)
        {
            foreach (var types in editTarif.AddExpenseTypes)
                if (types.Id == 0)
                    return BadRequest($"Услуга {types.Title} не существует");
            var tarif = (Tarif)editTarif;
            var oldTarif = await db.Tarifs.FindAsync(id);
            if (oldTarif == null)
                return NotFound();
            db.Entry(oldTarif).CurrentValues.SetValues(tarif);
            var typesRemove = db.CrossTarifAddExpenses.Where(s => s.IdTarif == id).ToList();
            db.CrossTarifAddExpenses.RemoveRange(typesRemove);
            await db.CrossTarifAddExpenses.AddRangeAsync(editTarif.AddExpenseTypes.Select(s => new CrossTarifAddExpense
            {
                IdTarif = tarif.Id,
                IdTypeExpense = s.Id
            }));
            await db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<TarifController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldTarif = await db.Tarifs.FindAsync(id);
            if (oldTarif == null)
                return NotFound();
            var types = db.CrossTarifAddExpenses.Where(s => s.IdTarif == id).ToList();
            db.CrossTarifAddExpenses.RemoveRange(types);
            db.Tarifs.Remove(oldTarif);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
