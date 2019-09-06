using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using MyApi.Response;
using MyApi.ServiceImpl;
using MyApi.Utility;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookServiceImpl _bookService;
        private ResponseStatus response;
        private BookValidator _validator;
        public BooksController()
        {
            _bookService = new BookServiceImpl();
            response = new ResponseStatus();
            _validator = new BookValidator();
        }
        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Book> books = _bookService.GetBook();
            if (books == null)
            {
                response.Model = null;
                response.Status.StatusCode = 400;
                response.Status.Message = "NO Books Available..!!";
                return BadRequest(response);
            }
            else
            {
                response.Model = books;
                response.Status.StatusCode = 200;
                response.Status.Message = "Success..!!";
            }
            return Ok(response);
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            Book book = _bookService.GetBookById(id);
            if (book == null)
            {
                response.Model = null;
                response.Status.StatusCode = 404;
                response.Status.Message = "Book not Found..!!";
                return NotFound(response);
            }
            else
            {
                response.Model = book;
                response.Status.StatusCode = 200;
                response.Status.Message = "Success..!!";
            }
            return Ok(response);

        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            List<String> exceptions = _bookService.AddBook(book);
            if (exceptions.Count > 0)
            {
                response.Model = book;
                response.Status.StatusCode = 400;
                response.Status.Message = string.Join(",",exceptions.ToArray());
                return BadRequest(response);
            }
            else
            {
                response.Model = null;
                response.Status.StatusCode = 200;
                response.Status.Message = "Success..!!";
                return Ok(response);
            }
        }


        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

