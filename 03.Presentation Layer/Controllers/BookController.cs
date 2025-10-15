using Microsoft.AspNetCore.Mvc;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle._03.Presentation_Layer.Filters;
using The_Book_Circle.DTOs;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById([FromQuery] int ID)
        {
            var result = await _bookService.GetBookByIdAsync(ID);

            return Ok(result);

            
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            
            var createdBook = await _bookService.CreateBookAsync(createBookDto);
            return Ok(createdBook);
        }

        [HttpPost("Search")]
        //[ServiceFilter(typeof(ValidateSearchQueryFilter))]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {

            var searchResult = await _bookService.SearchBooksAsync(query);

            return Ok(searchResult);
        }

    }
}
