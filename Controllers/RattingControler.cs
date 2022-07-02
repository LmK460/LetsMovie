using API.Dto;
using API.Dto.Comment;
using API.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RattingControler : ControllerBase
    {

        public RattingService RattingService { get; }

        public RattingControler(RattingService rattingService)
        {
            this.RattingService = rattingService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RattingDTO ratting)
        {
            var result = await RattingService.InsertRatting(ratting);
            if (result)
                return Created("avaliacao Inserida com sucesso", ratting);
            else
                return BadRequest(result);
        }
    }


}
