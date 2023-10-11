using Domain;

namespace Application.Library.Interfaces
{
    public interface ILibraryRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetBooksByAuthorAsync(string authorName);
        Task<List<Book>> GetAllCheckedOutBooks();
        Task<Book> GetBookByIsbnAsync(string isbn);

        Task<int> SaveChangesAsync(bool useTransaction = false);
    }
}
