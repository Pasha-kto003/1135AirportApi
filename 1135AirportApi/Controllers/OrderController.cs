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
    public class OrderController : ControllerBase
    {
        private readonly _1135_airportContext db;

        public OrderController(_1135_airportContext db)
        {
            this.db = db;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderApi> Get()
        {
            return db.Orders.ToList().Select(s=> {
                var transfers = db.Transfers.Where(t => t.IdOrder == s.Id).Select(t=>(TransferApi)t).ToList();
                return CreateOrderApi(s, transfers);
            });
        }

        private OrderApi CreateOrderApi(Order s, List<TransferApi> transfers)
        {
            var result = (OrderApi)s;
            result.Transfers = transfers;
            return result;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderApi>> Get(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if (order == null)
                return NotFound();
            var transfers = db.Transfers.Where(t => t.IdOrder == id).Select(t => (TransferApi)t).ToList();
            return Ok(CreateOrderApi(order, transfers));
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderApi newOrderApi)
        {
            var newOrder = (Order)newOrderApi;
            await db.Orders.AddAsync(newOrder);
            await db.SaveChangesAsync();
            var transfers = newOrderApi.Transfers.Select(s => (Transfer)s);
            foreach (var t in transfers)
                t.IdOrder = newOrder.Id;
            await db.Transfers.AddRangeAsync(transfers);
            await db.SaveChangesAsync();
            return Ok(newOrder.Id);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderApi editOrder)
        {
            var order = await db.Orders.FindAsync(id);
            if (order == null)
                return NotFound();
            db.Entry(order).CurrentValues.SetValues(editOrder);
            var transfers = db.Transfers.Where(s => s.IdTarif == id).ToList();
            db.Transfers.RemoveRange(transfers);
            var retransfers = editOrder.Transfers.Select(s => (Transfer)s);
            foreach (var t in retransfers)
                t.IdOrder = editOrder.Id;
            await db.Transfers.AddRangeAsync(retransfers);
            await db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldOrder = await db.Orders.FindAsync(id);
            if (oldOrder == null)
                return NotFound();
            var transfers = db.Transfers.Where(s => s.IdTarif == id).ToList();
            db.Transfers.RemoveRange(transfers);
            db.Orders.Remove(oldOrder);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
