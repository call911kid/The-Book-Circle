using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("index")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _authorService.GetAllAuthorsAsync();
          
            return Ok(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorById([FromQuery] int ID)
        {
            var result = await _authorService.GetAuthorByIdAsync(ID);

            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);
            
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            
            var result = await _authorService.CreateAuthorAsync(createAuthorDto);
            return Ok(result.Data);
        }
    }
}
