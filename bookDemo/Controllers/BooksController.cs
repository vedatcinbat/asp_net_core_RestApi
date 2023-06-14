using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookDemo.Models;
using bookDemo.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAllBooks([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (book is null)
            {
                return NotFound(); // 404
            }
            else
            {
                return Ok(book);
            }


        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book) {
            try
            {
                if (book is null) {
                    return BadRequest();
                } else
                {
                    ApplicationContext.Books.Add(book);
                    return StatusCode(201, book);
                }

            } catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            // check
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));

            if (entity is null)
            {
                return NotFound();
            }
            if (id != book.Id)
            {
                return BadRequest("Invalid argument");
            }

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteAllBook()
        {

            ApplicationContext.Books.Clear();
            return NoContent(); // 204

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.Books.Find(i => i.Id.Equals(id));

            if (entity is null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id:{id} could not found !"
                }); // 404
            }

            ApplicationContext.Books.Remove(entity);
            return Ok(entity);

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")]int id, JsonPatchDocument<Book> bookPatch)
        {

            var entity = ApplicationContext.Books.Find(i => i.Id.Equals(id));

            if(entity is null)
            {
                return NotFound(); // 404
            }
            bookPatch.ApplyTo(entity);
            return NoContent(); // 204
        
        }

    }
}

