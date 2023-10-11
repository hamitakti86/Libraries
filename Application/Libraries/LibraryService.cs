using Application.Core;
using Application.Library.Interfaces;
using Domain;

namespace Application.Library.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<List<Book>> GetBooksByAuthor(string authorName)
        {
            return await _libraryRepository.GetBooksByAuthorAsync(authorName);
        }

        public async Task<List<Book>> GetAllCheckedOutBooks()
        {
            return await _libraryRepository.GetAllCheckedOutBooks();
        }

        public async Task<Result<bool>> CheckOutBookAsync(string isbn)
        {
            var book = await _libraryRepository.GetBookByIsbnAsync(isbn);

            // Simulate a long-running operation
            await Task.Delay(TimeSpan.FromSeconds(2)); // Simulate a 2-second delay

            book.CheckedOut = true;

            var result = await _libraryRepository.SaveChangesAsync(true) > 0;

            if (!result)
                return Result<bool>.Failure("Failed to create order package");

            return Result<bool>.Success(true);
        }
    }
}
