using Application.Interfaces.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hi there!");
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync([FromBody] SearchBooksDto dto)
        {
            var response = await _bookService.SearchAsync(dto);

            return Ok(response);
        }

    }
}
