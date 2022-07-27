using MEtechnology.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEtechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseProdutosController : ControllerBase
    {
        private MeContext DbSistema = new MeContext();

        [HttpGet]
        public ActionResult<List<ClasseProdutos>> Requeretodos()
        {
            var aux = DbSistema.ClasseProdutos.ToList();

            if(aux == null) 
            { return NotFound(); } 
            else 
            { return Ok(aux); }
            
        }

        [HttpGet ("{Id}")]
        public ActionResult<List<ClasseProdutos>> RequererUmPeloId(int Id)
        {
            var aux = DbSistema.ClasseProdutos?.Find(Id);

            if (aux == null)
            { return NotFound(); } // status 404
            else
            { return Ok(aux); }
        }

        [HttpPost]
        public ActionResult<List<ClasseProdutos>> Publicartodos(ClasseProdutos auxClasseProdutos)
        {
            DbSistema.ClasseProdutos?.Add(auxClasseProdutos);
            DbSistema.SaveChanges();

            return CreatedAtAction("RequererUmPeloId", new { Id = auxClasseProdutos.Id}, auxClasseProdutos);
        }

        [HttpDelete("{Id}")]
        public ActionResult<List<ClasseProdutos>> DeletarPeloId(int Id)
        {
            var aux = DbSistema.ClasseProdutos?.Find(Id);

            if (aux == null)
            {  return NotFound(); }
            else{
                DbSistema.ClasseProdutos?.Remove(aux);
                DbSistema.SaveChanges();
                return NoContent();
            }
        }    

        [HttpPut("{Id}")]
        public ActionResult<List<ClasseProdutos>> SubtituirPeloId(int Id, ClasseProdutos auxClasseProduto)
        {
            if (Id != auxClasseProduto.Id)
            {  return BadRequest(); }
            else
            {
                DbSistema.Entry(auxClasseProduto).State = EntityState.Modified;
                DbSistema.SaveChanges();
                // Retorno apenas o status 204 - No Content.
                return NoContent();
            }
        }

    }
}
