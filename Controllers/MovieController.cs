using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class MovieController : ControllerBase
    {
        public MovieService MovieService { get; }

        public MovieController(MovieService movieService)
        {
            this.MovieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GET([FromHeader] string? i, [FromHeader] string? t)
        {
            if(i is null && t is  null)
            {
                return BadRequest("Pelo menos um parametro é obrigatorio");
            }
            if (i is not null && t is not null)
            {
                return BadRequest("Pelo menos um parametro é obrigatorio");
            }

            if (i is not null)
            {
                var result = await MovieService.GetFilmeById(i);
                return Ok(result);
            }
            if(t is not null)
            {
                var result = await MovieService.GetFilmeByTittle(t);
                return Ok(result);
            }
            
            return BadRequest();
        }


    }
}
