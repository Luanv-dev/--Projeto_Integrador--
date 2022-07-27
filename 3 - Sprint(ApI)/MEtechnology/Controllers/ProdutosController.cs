using MEtechnology.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEtechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private MeContext DbSistema = new MeContext();

        [HttpGet]
        public ActionResult<List<Produtos>> Requeretodos()
        {
            var aux = DbSistema.Produtos.ToList();

            if (aux == null)
            { return NotFound(); }
            else
            { return Ok(aux); }
        }

        [HttpGet("{Id}")]
        public ActionResult<List<Produtos>> RequererUmPeloId(int Id)
        {
            var aux = DbSistema.Produtos?.Find(Id);

            if (aux == null)
            { return NotFound(); } // status 404
            else
            { return Ok(aux); }
        }

        [HttpPost]
        public ActionResult<List<Produtos>> Publicartodos(Produtos auxProdutos)
        {
            DbSistema.Produtos?.Add(auxProdutos);
            DbSistema.SaveChanges();

            return CreatedAtAction("RequererUmPeloId", new { Id = auxProdutos.Id }, auxProdutos);
        }

        [HttpDelete("{Id}")]
        public ActionResult<List<Produtos>> DeletarPeloId(int Id)
        {
            var aux = DbSistema.Produtos?.Find(Id);

            if (aux == null)
            { return NotFound(); }
            else
            {
                DbSistema.Produtos?.Remove(aux);
                DbSistema.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<List<Produtos>> SubtituirPeloId(int Id, Produtos auxProdutos)
        {
            if (Id != auxProdutos.Id)
            { return BadRequest(); }
            else
            {
                DbSistema.Entry(auxProdutos).State = EntityState.Modified;
                DbSistema.SaveChanges();
                // Retorno apenas o status 204 - No Content.
                return NoContent();
            }
        }
    }
}
