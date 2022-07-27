using MEtechnology.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEtechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private MeContext DbSistema = new MeContext();
        [HttpGet]
        public ActionResult<List<Login>> Requeretodos()
        {
            var aux = DbSistema.Login.ToList();

            if (aux == null)
            { return NotFound(); }
            else
            { return Ok(aux); }
        }

        [HttpGet("{Id}")]
        public ActionResult<List<Login>> RequererUmPeloId(int Id)
        {
            var aux = DbSistema.Login?.Find(Id);

            if (aux == null)
            { return NotFound(); } // status 404
            else
            { return Ok(aux); }
        }

        [HttpPost]
        public ActionResult<List<Login>> Publicartodos(Login auxLogin)
        {
            DbSistema.Login?.Add(auxLogin);
            DbSistema.SaveChanges();

            return CreatedAtAction("RequererUmPeloId", new { Id = auxLogin.Id }, auxLogin);
        }
       
        [HttpDelete("{Id}")]
        public ActionResult<List<Login>> DeletarPeloId(int Id)
        {
            var aux = DbSistema.Login?.Find(Id);

            if (aux == null)
            { return NotFound(); }
            else
            {
                DbSistema.Login?.Remove(aux);
                DbSistema.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<List<Login>> SubtituirPeloId(int Id, Login auxLogin)
        {
            if (Id != auxLogin.Id)
            { return BadRequest(); }
            else
            {
                DbSistema.Entry(auxLogin).State = EntityState.Modified;
                DbSistema.SaveChanges();
                // Retorno apenas o status 204 - No Content.
                return NoContent();
            }
        }

    }
}
