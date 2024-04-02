using Microsoft.AspNetCore.Mvc;
using StaticLibrary.WebUI.Models;
using StaticLibrary.WebUI.Services.Repository.BookRepository;
using System.Diagnostics;

namespace StaticLibrary.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : GenericController<Book>
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepo _bookRepo;

        public BookController(ILogger<BookController> logger, IBookRepo bookRepo) : base(logger, bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
        }

        //// /api/book/search-book-by-name
        //[HttpGet, ActionName("search-book-by-name")]
        //public IActionResult SearchBookByName(string name)
        //{
        //    Response response;

        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        response = new Response(false, "name should not be empty", null);

        //        return BadRequest(response);
        //    }

        //    List<Book>? availableBooks = _bookRepo.GetBooksByName(name);
        //    if(availableBooks is null || !availableBooks.Any())
        //    {
        //        response = new Response(false, $"No books found with name {name}", null);

        //        return NotFound(response);
        //    }

        //    response = new Response(true, string.Empty, availableBooks);

        //    return Ok(response);
        //}
    }
}