using ExampleRabbitMQ.API1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleRabbitMQ.API1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        [HttpPost]
        public IActionResult createUser(User user) {
            return Ok("Usuário criado com sucesso");
        }
    }
}
