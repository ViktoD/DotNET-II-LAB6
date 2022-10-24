using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class BookServices
    {
        protected readonly DbConnection _db;
        public BookServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetBooks()
        {
             
            return await _db.Books.OrderBy(p => p.Name).ToListAsync(); ;
        }

        public async Task<Book> GetBook(int id)
        {
            return await _db.Books.FirstAsync(p => p.ID == id);
        }

        public async Task AddBook(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task EditBook(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
        }
    }
}
