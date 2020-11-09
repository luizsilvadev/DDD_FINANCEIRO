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
    public class SugestoesController : ControllerBase
    {
        private readonly FINANCEIROContext _context;

        public SugestoesController(FINANCEIROContext context)
        {
            _context = context;
        }

        // GET: api/Sugestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sugestao>>> GetSugestao()
        {
            var lista = await _context.Sugestao.ToListAsync();

            if (lista.Count() > 0)
                return Ok(lista);
            else
                return BadRequest(new List<Sugestao>());
        }

        // GET: api/Sugestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sugestao>> GetSugestao(int id)
        {
            var sugestao = await _context.Sugestao.FindAsync(id);

            if (sugestao == null)
            {
                return NotFound();
            }

            return sugestao;
        }

        // PUT: api/Sugestoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSugestao(int id, Sugestao sugestao)
        {
            if (id != sugestao.Id)
            {
                return BadRequest();
            }

            _context.Entry(sugestao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugestaoExists(id))
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

        // POST: api/Sugestoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sugestao>> PostSugestao(Sugestao sugestao)
        {
            _context.Sugestao.Add(sugestao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSugestao", new { id = sugestao.Id }, sugestao);
        }

        // DELETE: api/Sugestoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sugestao>> DeleteSugestao(int id)
        {
            var sugestao = await _context.Sugestao.FindAsync(id);
            if (sugestao == null)
            {
                return NotFound();
            }

            _context.Sugestao.Remove(sugestao);
            await _context.SaveChangesAsync();

            return sugestao;
        }

        private bool SugestaoExists(int id)
        {
            return _context.Sugestao.Any(e => e.Id == id);
        }
    }
}
