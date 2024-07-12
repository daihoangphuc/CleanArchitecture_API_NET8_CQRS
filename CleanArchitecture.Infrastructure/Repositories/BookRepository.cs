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

        public async Task DeleteBookAsync(int id)
        {
            await _dbContext.Books.Where(b => b.BookId == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            _dbContext.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('Books', RESEED, {id-1});");
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.Where(b => b.BookId == id).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
             _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
