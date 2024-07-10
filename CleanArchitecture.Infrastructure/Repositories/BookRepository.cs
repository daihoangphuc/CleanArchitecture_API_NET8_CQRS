using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public Task DeleteBookAsync(int id)
        {
            return _dbContext.Books
                .Where(b => b.BookId == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                .Where(b => b.BookId == id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            await _dbContext.Books
                .Where(b => b.BookId == book.BookId)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(b => b.BookTitle, book.BookTitle)
                    .SetProperty(b => b.BookDescription, book.BookDescription)
                    .SetProperty(b => b.BookAuthor, book.BookAuthor));
        }
    }
}
