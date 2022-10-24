using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class InfoBookServices
    {
        protected readonly DbConnection _db;
        private readonly TicketServices _ticketServices;
        private readonly BookServices _bookServices;
        public InfoBookServices(DbConnection db)
        {
            _db = db;
            _ticketServices = new TicketServices(_db);
            _bookServices = new BookServices(_db);

        }

        public async Task<List<InfoBook>> GetInfoBooks()
        {
            return await _db.InfoBooks.Include(p => p.Ticket).Include(p => p.Book).Include(p => p.Ticket.Reader).OrderBy(p => p.Ticket.Reader.Surname).ToListAsync();
        }

        public async Task<InfoBook> GetInfoBook(int id)
        {
            return await _db.InfoBooks.FirstAsync(p => p.ID == id);
        }

        public async Task<List<Ticket>> GetTicketsFromInfo()
        {
            return await _ticketServices.GetTickets();
        }

        public async Task<List<Book>> GetBooksFromInfo()
        {
            return await _bookServices.GetBooks();
        }
        public async Task AddInfoBook(InfoBook infoBook)
        {
            await _db.InfoBooks.AddAsync(infoBook);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteInfoBook(InfoBook infoBook)
        {
            _db.InfoBooks.Remove(infoBook);
            await _db.SaveChangesAsync();
        }
    }
}
