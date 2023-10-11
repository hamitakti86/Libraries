using Application.Library.Services;
using Moq;
using Application.Library.Interfaces;
using Domain;

namespace Library.Tests
{
    public class LibraryServiceTests
    {
        [Fact]
        public async Task GetBooksByAuthor_Should_Return_No_Books()
        {
            // Arrange
            var authorName = "TestAuthor";
            var libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(repo => repo.GetBooksByAuthorAsync(authorName))
                                .ReturnsAsync(new List<Book>());

            var libraryService = new LibraryService(libraryRepositoryMock.Object);

            // Act
            var result = await libraryService.GetBooksByAuthor(authorName);

            // Assert
            Assert.NotNull(result);
            // Add more specific assertions here based on the expected behavior
        }

        [Fact]
        public async Task GetBooksByAuthor_Should_Return_Books()
        {
            // Arrange
            var authorName = "Dan Brown";
            var libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(repo => repo.GetBooksByAuthorAsync(authorName))
                                .ReturnsAsync(new List<Book>());

            var libraryService = new LibraryService(libraryRepositoryMock.Object);

            // Act
            var result = await libraryService.GetBooksByAuthor(authorName);

            // Assert
            Assert.NotNull(result);
            // Add more specific assertions here based on the expected behavior
        }

        [Fact]
        public async Task GetAllCheckedOut_Should_Return_Books()
        {

            var libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(repo => repo.GetAllCheckedOutBooks())
                                .ReturnsAsync(new List<Book>());

            var libraryService = new LibraryService(libraryRepositoryMock.Object);

            // Act
            var result = await libraryService.GetAllCheckedOutBooks();

            // Assert
            Assert.NotNull(result);
            // Add more specific assertions here based on the expected behavior
        }

        [Fact]
        public async Task CheckOutBookAsync_Should_CheckOut_False_Book()
        {
            // Arrange
            var isbn = "TestISBN";
            var libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(repo => repo.GetBookByIsbnAsync(isbn))
                                .ReturnsAsync(new Book { ISBN = isbn });
            libraryRepositoryMock.Setup(repo => repo.SaveChangesAsync(true))
                                .ReturnsAsync(1);

            var libraryService = new LibraryService(libraryRepositoryMock.Object);

            // Act
            var result = await libraryService.CheckOutBookAsync(isbn);

            // Assert
            Assert.True(result.IsSuccess);
            // Add more specific assertions here based on the expected behavior
        }

        [Fact]
        public async Task CheckOutBookAsync_Should_CheckOut_Book()
        {
            // Arrange
            var isbn = "333";
            var libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(repo => repo.GetBookByIsbnAsync(isbn))
                                .ReturnsAsync(new Book { ISBN = isbn });
            libraryRepositoryMock.Setup(repo => repo.SaveChangesAsync(true))
                                .ReturnsAsync(1);

            var libraryService = new LibraryService(libraryRepositoryMock.Object);

            // Act
            var result = await libraryService.CheckOutBookAsync(isbn);

            // Assert
            Assert.True(result.IsSuccess);
            // Add more specific assertions here based on the expected behavior
        }
    }
}
