using API.Dto;
using API.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        public CommentService CommentService { get; set; }

        public CommentController(CommentService commentService)
        {
            CommentService = commentService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentDTO commentDTO)
        {
            var comment = new Comment { Commentary = commentDTO.Commentary,ImdbId=commentDTO.ImdbId,UserName = commentDTO.UserName };
            var result = await CommentService.InsertComment(comment);
            if(result is not null)
                return Created("Comentario Inserido com sucesso", commentDTO);
            else
            return BadRequest(result);
        }

    }
}
