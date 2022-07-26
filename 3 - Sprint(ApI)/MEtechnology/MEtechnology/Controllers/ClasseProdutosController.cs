using MEtechnology.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEtechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseProdutosController : ControllerBase
    {
        private MeContext DbSistema = new MeContext();

        [HttpGet]



    }
}
