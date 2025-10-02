using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle.DTOs;
using The_Book_Circle.Services.Interfaces;

namespace The_Book_Circle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpGet("index")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var result = await _publisherService.GetAllPublishersAsync();
            return Ok(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPublisherById([FromQuery] int ID)
        {
            var result = await _publisherService.GetPublisherByIdAsync(ID);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateGenre([FromBody] CreatePublisherDto createPublisherDto)
        {

            var result = await _publisherService.CreatePublisherAsync(createPublisherDto);
            return Ok(result.Data);
        }

    }
}
