using BookMyShowAPI.Model;
using BookMyShowAPI.Services.AuthenticationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticateService _tokenManager;


        public TokenController(IAuthenticateService jwtTokenManager)
        {
            _tokenManager = jwtTokenManager;
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] ContactLogin login)
        {
            var token=_tokenManager.Authenticate(login.UserEmail,login.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return (Ok(token));
        
        }
        
    }
}
