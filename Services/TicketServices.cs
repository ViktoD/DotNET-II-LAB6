using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class TicketServices
    {
        protected readonly DbConnection _db;
        private readonly ReaderServices _readerService;
        public TicketServices(DbConnection db)
        {
            _db = db;
            _readerService = new ReaderServices(_db);

        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await _db.Tickets.Include(p => p.Reader).ToListAsync();
        }

        public async Task<List<Reader>> GetReadersFromTickets()
        {
            return await _readerService.GetReaders();
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await _db.Tickets.FirstAsync(p => p.ID == id);
        }

        public async Task AddTicket(Ticket ticket)
        {
            await _db.Tickets.AddAsync(ticket);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTicket(Ticket ticket)
        {
            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();
        }
    }
}
