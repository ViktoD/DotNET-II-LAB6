using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class ReaderServices
    {
        protected readonly DbConnection _db;

        public ReaderServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Reader>> GetReaders()
        {
            return await _db.Readers.OrderBy(p => p.Surname).ToListAsync();
        }

        public async Task<Reader> GetReader(int id)
        {
            return await _db.Readers.FirstAsync(p => p.ID == id);
        }

        public async Task AddReader(Reader reader)
        {
            await _db.Readers.AddAsync(reader);
            await _db.SaveChangesAsync();
        }

        public async Task EditReader(Reader reader)
        {
            _db.Readers.Update(reader);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReader(Reader reader)
        {
            _db.Readers.Remove(reader);
            await _db.SaveChangesAsync(); 
        }
    }
}
