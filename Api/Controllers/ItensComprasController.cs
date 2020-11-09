using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFinanceiroApi;
using WebFinanceiroApi.Models;

namespace WebFinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensComprasController : ControllerBase
    {
        private readonly FINANCEIROContext _context;

        public ItensComprasController(FINANCEIROContext context)
        {
            _context = context;
        }

        // GET: api/ItensCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCompra>>> GetItemCompra()
        {
            return await _context.ItemCompra.ToListAsync();
        }

        // GET: api/ItensCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCompra>> GetItemCompra(int id)
        {
            var itemCompra = await _context.ItemCompra.FindAsync(id);

            if (itemCompra == null)
            {
                return NotFound();
            }

            return itemCompra;
        }

        // PUT: api/ItensCompras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCompra(int id, ItemCompra itemCompra)
        {
            if (id != itemCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItensCompras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemCompra>> PostItemCompra(ItemCompra itemCompra)
        {
            _context.ItemCompra.Add(itemCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCompra", new { id = itemCompra.Id }, itemCompra);
        }

        // DELETE: api/ItensCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCompra>> DeleteItemCompra(int id)
        {
            var itemCompra = await _context.ItemCompra.FindAsync(id);
            if (itemCompra == null)
            {
                return NotFound();
            }

            _context.ItemCompra.Remove(itemCompra);
            await _context.SaveChangesAsync();

            return itemCompra;
        }

        private bool ItemCompraExists(int id)
        {
            return _context.ItemCompra.Any(e => e.Id == id);
        }
    }
}
