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
    public class UsuariosSistemasFinanceirosController : ControllerBase
    {
        private readonly FINANCEIROContext _context;

        public UsuariosSistemasFinanceirosController(FINANCEIROContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosSistemasFinanceiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioSistemaFinanceiro>>> GetUsuarioSistemaFinanceiro()
        {
            return await _context.UsuarioSistemaFinanceiro.ToListAsync();
        }

        // GET: api/UsuariosSistemasFinanceiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioSistemaFinanceiro>> GetUsuarioSistemaFinanceiro(int id)
        {
            var usuarioSistemaFinanceiro = await _context.UsuarioSistemaFinanceiro.FindAsync(id);

            if (usuarioSistemaFinanceiro == null)
            {
                return NotFound();
            }

            return usuarioSistemaFinanceiro;
        }

        // PUT: api/UsuariosSistemasFinanceiros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioSistemaFinanceiro(int id, UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            if (id != usuarioSistemaFinanceiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioSistemaFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioSistemaFinanceiroExists(id))
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

        // POST: api/UsuariosSistemasFinanceiros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioSistemaFinanceiro>> PostUsuarioSistemaFinanceiro(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            _context.UsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioSistemaFinanceiro", new { id = usuarioSistemaFinanceiro.Id }, usuarioSistemaFinanceiro);
        }

        // DELETE: api/UsuariosSistemasFinanceiros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioSistemaFinanceiro>> DeleteUsuarioSistemaFinanceiro(int id)
        {
            var usuarioSistemaFinanceiro = await _context.UsuarioSistemaFinanceiro.FindAsync(id);
            if (usuarioSistemaFinanceiro == null)
            {
                return NotFound();
            }

            _context.UsuarioSistemaFinanceiro.Remove(usuarioSistemaFinanceiro);
            await _context.SaveChangesAsync();

            return usuarioSistemaFinanceiro;
        }

        private bool UsuarioSistemaFinanceiroExists(int id)
        {
            return _context.UsuarioSistemaFinanceiro.Any(e => e.Id == id);
        }
    }
}
