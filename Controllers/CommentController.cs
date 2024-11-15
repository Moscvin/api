using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllSync();

            var commentDto = comments.Select(c => c.ToCommentDto()).ToList();
            return Ok(commentDto);
        }
    }
}