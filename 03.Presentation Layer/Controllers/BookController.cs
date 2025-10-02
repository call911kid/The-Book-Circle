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
        [HttpPost("Test")]
        public async Task<IActionResult> Test(CreateBookDto X)
        {
            Console.WriteLine(ModelState.IsValid ? "VVVVVVVVVV" : "ZZZZZZ");
            return Ok();
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

            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);

            
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            Console.WriteLine("Testing Endpoint");
            //throw new Exception("This is a test exception");
            var createdBook = await _bookService.CreateBookAsync(createBookDto);
            return Ok(createdBook);
        }

        [HttpPost("Search")]
        //[ServiceFilter(typeof(ValidateSearchQueryFilter))]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {

            var searchResult = await _bookService.SearchBooksAsync(query);
            if (!searchResult.IsSuccess)
            {
                return NotFound(new ApiResponse<IEnumerable<BookDto>>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = searchResult.Error
                });
            }
            return Ok(new ApiResponse<IEnumerable<BookDto>>
            {
                IsSuccess = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "Books retrieved successfully",
                Data = searchResult.Data

            });
        }

    }
}
