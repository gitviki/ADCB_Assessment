using BookManagerAPI.Business_Logics;
using BookManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        /// <summary>
        /// Get all the books
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookRepo.GetAllBooks();

            return Ok(books);
        }

        /// <summary>
        /// Get the book by its ID
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>Book object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookByID(id);

                if (book == null)
                {
                    return NotFound();
                }

                return book;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Book newBook)
        {
            try
            {
                if (newBook == null)
                {
                    return BadRequest();
                }

                var createdBook = await _bookRepo.CreateBook(newBook);

                return CreatedAtAction(nameof(GetById),
                    new { id = newBook.BookID }, createdBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Book record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Edit(int id, [FromBody] Book book)
        {
            try
            {
                if (id != book.BookID)
                {
                    return BadRequest("Book ID mismatch");
                }

                var updatedBook = await _bookRepo.EditBook(book);

                if (updatedBook != null)
                {
                    return Ok(updatedBook);
                }
                else
                {
                    return NotFound($"Book with Id = {id} not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            try
            {
                var deletedBook = await _bookRepo.DeleteBook(id);

                if (deletedBook != null)
                {
                    return Ok(deletedBook);
                }
                else
                {
                    return NotFound($"Book with Id = {id} not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
