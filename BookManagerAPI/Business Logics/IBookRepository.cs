using BookManagerAPI.Models;

namespace BookManagerAPI.Business_Logics
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book?> GetBookByID(int bookID);

        Task<Book> CreateBook(Book book);

        Task<Book?> EditBook(Book book);

        Task<Book?> DeleteBook(int bookID);
    }
}
