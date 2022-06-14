using BookMyShowAPI.Model;
using BookMyShowAPI.Services.TicketServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("get")]
        public IEnumerable<Ticket> Get()
        {
            return _ticketService.GetAll();
        }

        [HttpGet("getId/{ticketId}")]
        public Ticket Get(int ticketId)
        {
            return _ticketService.GetById(ticketId);
        }

        [HttpPost("add")]
        public int Post([FromBody] Ticket ticket)
        {
            if (ModelState.IsValid)
                return _ticketService.Add(ticket);

            return -1;
        }

      

        [HttpDelete("delete/{ticketId}")]

        public void Delete(int ticketId)
        {
            _ticketService.Delete(ticketId);

        }
    }
}
