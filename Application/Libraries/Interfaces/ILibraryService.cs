using Application.Core;
using Domain;
using MediatR;

namespace Application.Library.Interfaces
{
    public interface ILibraryService
    {
        Task<List<Book>> GetBooksByAuthor(string authorName);
        Task<List<Book>> GetAllCheckedOutBooks();
        Task<Result<bool>> CheckOutBookAsync(string isbn);
    }
}