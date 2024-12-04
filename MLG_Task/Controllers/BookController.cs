using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MLG_Task.Application.Services;
using MLG_Task.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using MLG_Task.Dtos.Book;

namespace MLG_Task.Controllers
{
    [Route("api/[controller]/")]

    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("GetAllWithPaging")]
        public async Task<IActionResult>  GetAllAsync(int items, int pageNumber = 1)
        {
            var model = await _bookService.GetAllPagination(items, pageNumber);
            if (model == null)
            {
                return BadRequest("Empty ");
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("GetBookByID/{ID}")]
        public async Task<IActionResult> GetBookAsync(int ID)
        {
            var model = await _bookService.GetBookByID(ID);
            if (model == null)
            {
                return BadRequest(" not found");
            }
            return Ok(model);
        }
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBookAsync([FromBody]AddOrUpdateBookDto book)
        {
            var result = await _bookService.CreateBook(book);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] AddOrUpdateBookDto book)
        {
            var result = await _bookService.UpdateBook(id,book);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete]
        [Route("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await _bookService.SoftDelete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete]
        [Route("HardDelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _bookService.HardDelete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
