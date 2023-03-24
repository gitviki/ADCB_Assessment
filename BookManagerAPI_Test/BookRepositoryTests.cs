using BookManagerAPI.Business_Logics;
using BookManagerAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookManagerAPITest
{
    public class BookRepositoryTests
    {
        [Fact]
        public async Task GetAllBooks_ShouldReturn200Status()
        {
            //Arrange
            var bookRepository = new Mock<IBookRepository>();
            bookRepository.Setup(x => x.GetAllBooks()).ReturnsAsync(TestData.GetBooks());
            var bookController = new BookController(bookRepository.Object);

            //Act
            var result = await bookController.GetAllBooks();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.True(((OkObjectResult)result.Result).StatusCode == 200);
            Assert.Equivalent(TestData.GetBooks(), ((OkObjectResult)result.Result).Value);
        }
    }
}