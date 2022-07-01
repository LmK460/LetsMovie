using API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserLoginDTO userLoginDTO)
        {

            return Ok(userLoginDTO);
        }

    }
}
