using BookMyShowAPI.Model;

namespace BookMyShowAPI.Services.ContactServices
{
    public interface IContactService
    {
        void Add(Contact user);
        void update(Contact user);
        IEnumerable<Contact> GetAll();
       Contact GetById(int UserId);
        void Delete(int UserId);
    }
}
