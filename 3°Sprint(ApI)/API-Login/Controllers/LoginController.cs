using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{

    public LoginController()
    {
    }

    [HttpPost()]
    public string Post([FromBody]LoginDTO dto)
    {
        if(dto.Email == "email@email.com" && dto.Senha == "1234") {
            return "Login com sucesso";
        } else {
            return "Email ou senha inválida";
        }
    }
}
