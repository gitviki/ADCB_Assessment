using BookManagerAPI.Models;

namespace BookManagerAPITest
{
    internal class TestData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Year = 1960,
                    ISBN = "9780446310789"
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Year = 1949,
                    ISBN = "9780451524935"
                },
                new Book
                {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Year = 1925,
                    ISBN = "9780743273565"
                },
                new Book
                {
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    Year = 1954,
                    ISBN = "9780547928203"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Year = 1813,
                    ISBN = "9780141439518"
                }
            };
        }
    }
}
