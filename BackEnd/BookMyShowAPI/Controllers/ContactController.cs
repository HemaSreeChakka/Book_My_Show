using BookMyShowAPI.Model;
using BookMyShowAPI.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("get")]
        public IEnumerable<Contact> Get()
        {
            return _contactService.GetAll();
        }

        [HttpGet("getId/{UserId}")]
        public Contact Get(int UserId)
        {
            return _contactService.GetById(UserId);
        }

        [HttpPost("add")]
        public void Post([FromBody] Contact user)
        {
            if (ModelState.IsValid)
                _contactService.Add(user);
        }

        [HttpPut("update/{UserId}")]
        public void Put(int UserId, [FromBody] Contact user)
        {
            user.UserId = UserId;
            if (ModelState.IsValid)
                _contactService.update(user);
        }

        [HttpDelete("delete/{UserId}")]

        public void Delete(int UserId)
        {
            _contactService.Delete(UserId);

        }
    }
}
