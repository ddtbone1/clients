using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Dto.CommentDto;
using clientsApi.Interfaces;
using clientsApi.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace clientsApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IClientRepository _clientRepo;
        public CommentController(ICommentRepository commentRepo, IClientRepository clientRepo)
        {
            _commentRepo = commentRepo;
            _clientRepo = clientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _commentRepo.GetAllAsync();
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{clientId:int}")]
        public async Task<IActionResult> CreateComment([FromRoute] int clientId, [FromBody] CreateCommentDto createCommentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _clientRepo.ClientExists(clientId))
            {
                return BadRequest($"Client does not exist.");
            }

            var comment = createCommentDto.ToComment(clientId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.UpdateAsync(id, updateCommentDto);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }
    }
}   