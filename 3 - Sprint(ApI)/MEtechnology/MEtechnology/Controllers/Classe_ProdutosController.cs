using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEtechnology.Models;

namespace MEtechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Classe_ProdutosController : ControllerBase
    {
        private readonly MeContext _context;

        public Classe_ProdutosController(MeContext context)
        {
            _context = context;
        }

        // GET: api/Classe_Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classe_Produtos>>> GetClasse_Produtos()
        {
          if (_context.Classe_Produtos == null)
          {
              return NotFound();
          }
            return await _context.Classe_Produtos.ToListAsync();
        }

        // GET: api/Classe_Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classe_Produtos>> GetClasse_Produtos(string id)
        {
          if (_context.Classe_Produtos == null)
          {
              return NotFound();
          }
            var classe_Produtos = await _context.Classe_Produtos.FindAsync(id);

            if (classe_Produtos == null)
            {
                return NotFound();
            }

            return classe_Produtos;
        }

        // PUT: api/Classe_Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasse_Produtos(string id, Classe_Produtos classe_Produtos)
        {
            if (id != classe_Produtos.Classe)
            {
                return BadRequest();
            }

            _context.Entry(classe_Produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Classe_ProdutosExists(id))
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

        // POST: api/Classe_Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classe_Produtos>> PostClasse_Produtos(Classe_Produtos classe_Produtos)
        {
          if (_context.Classe_Produtos == null)
          {
              return Problem("Entity set 'MeContext.Classe_Produtos'  is null.");
          }
            _context.Classe_Produtos.Add(classe_Produtos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Classe_ProdutosExists(classe_Produtos.Classe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClasse_Produtos", new { id = classe_Produtos.Classe }, classe_Produtos);
        }

        // DELETE: api/Classe_Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasse_Produtos(string id)
        {
            if (_context.Classe_Produtos == null)
            {
                return NotFound();
            }
            var classe_Produtos = await _context.Classe_Produtos.FindAsync(id);
            if (classe_Produtos == null)
            {
                return NotFound();
            }

            _context.Classe_Produtos.Remove(classe_Produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Classe_ProdutosExists(string id)
        {
            return (_context.Classe_Produtos?.Any(e => e.Classe == id)).GetValueOrDefault();
        }
    }
}
