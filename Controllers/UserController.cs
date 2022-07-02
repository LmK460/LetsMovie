﻿using API.Dto;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
