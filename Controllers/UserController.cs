using API.Dto;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {

        public UserService UserService { get; }

        public UserController(UserService userService)
        {
            this.UserService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInsertDTO UserLoginDTO)
        {

            var result = await UserService.InsertUser(UserLoginDTO);
            if (result = true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
