using BookMyShowAPI.Model;

namespace BookMyShowAPI.Services.AuthenticationServices
{
    public interface IAuthenticateService
    {
        string Authenticate(string userEmail, string password);

    }
}
