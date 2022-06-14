using BookMyShowAPI.Model;

namespace BookMyShowAPI.Services.TicketServices
{
    public interface ITicketService
    {
        int Add(Ticket ticket);
    
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int transactionId);
        void Delete(int transactionId);
    }
}
