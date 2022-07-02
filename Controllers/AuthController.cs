using API.Dto;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthService AuthService { get; }

        public AuthController(AuthService AuthService)
        {
            this.AuthService = AuthService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserLoginDTO UserLoginDTO)
        {

            var result = await AuthService.Login(UserLoginDTO);
            if (result.Autenticated = true)
            {
                var aux = AuthService.ValidateToken(result.AccessToken);
                Console.WriteLine(aux);
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
