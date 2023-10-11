using Application.Library.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly DataContext _context;
        public LibraryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(bool useTransaction = false)
        {
            if (useTransaction)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        int result = await _context.SaveChangesAsync();
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                return await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task<List<Book>> GetBooksByAuthorAsync(string authorName)
        {
            return await _context.Books.Where(book => book.Author.Name == authorName).ToListAsync();
        }

        public async Task<List<Book>> GetAllCheckedOutBooks()
        {
            return await _context.Books.Where(book => book.CheckedOut).ToListAsync();
        }

        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);

        }
    }
}
