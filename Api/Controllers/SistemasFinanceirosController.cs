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
    public class SistemasFinanceirosController : ControllerBase
    {
        private readonly FINANCEIROContext _context;

        public SistemasFinanceirosController(FINANCEIROContext context)
        {
            _context = context;
        }

        // GET: api/SistemasFinanceiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemaFinanceiro>>> GetSistemaFinanceiro()
        {
            return await _context.SistemaFinanceiro.ToListAsync();
        }

        // GET: api/SistemasFinanceiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaFinanceiro>> GetSistemaFinanceiro(int id)
        {
            var sistemaFinanceiro = await _context.SistemaFinanceiro.FindAsync(id);

            if (sistemaFinanceiro == null)
            {
                return NotFound();
            }

            return sistemaFinanceiro;
        }

        // PUT: api/SistemasFinanceiros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaFinanceiro(int id, SistemaFinanceiro sistemaFinanceiro)
        {
            if (id != sistemaFinanceiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(sistemaFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaFinanceiroExists(id))
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

        // POST: api/SistemasFinanceiros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SistemaFinanceiro>> PostSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            _context.SistemaFinanceiro.Add(sistemaFinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSistemaFinanceiro", new { id = sistemaFinanceiro.Id }, sistemaFinanceiro);
        }

        // DELETE: api/SistemasFinanceiros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SistemaFinanceiro>> DeleteSistemaFinanceiro(int id)
        {
            var sistemaFinanceiro = await _context.SistemaFinanceiro.FindAsync(id);
            if (sistemaFinanceiro == null)
            {
                return NotFound();
            }

            _context.SistemaFinanceiro.Remove(sistemaFinanceiro);
            await _context.SaveChangesAsync();

            return sistemaFinanceiro;
        }

        private bool SistemaFinanceiroExists(int id)
        {
            return _context.SistemaFinanceiro.Any(e => e.Id == id);
        }
    }
}
