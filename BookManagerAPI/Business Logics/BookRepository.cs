using BookManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerAPI.Business_Logics
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookDbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByID(int bookID)
        {
            return await _bookDbContext.Books
                    .SingleOrDefaultAsync(b => b.BookID == bookID);
        }

        public async Task<Book> CreateBook(Book book)
        {
            await _bookDbContext.Books.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> EditBook(Book book)
        {
            var bookToUpdate = await _bookDbContext.Books
                    .SingleOrDefaultAsync(b => b.BookID == book.BookID);

            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Title = book.Title;
                bookToUpdate.Year = book.Year;

                await _bookDbContext.SaveChangesAsync();
            }

            return bookToUpdate;
        }

        public async Task<Book?> DeleteBook(int bookID)
        {
            var bookToDelete = await _bookDbContext.Books
                    .SingleOrDefaultAsync(b => b.BookID == bookID);

            if (bookToDelete != null)
            {
                _bookDbContext.Books.Remove(bookToDelete);

                await _bookDbContext.SaveChangesAsync();
            }

            return bookToDelete;
        }
    }
}
