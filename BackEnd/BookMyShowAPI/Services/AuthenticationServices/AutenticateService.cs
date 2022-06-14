using BookMyShowAPI.Model;
using Dapper;
using BookMyShowAPI.Services.ContactServices;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookMyShowAPI.Services.AuthenticationServices
{


    public class AutenticateService : IAuthenticateService
    {

    
        private readonly IConfiguration _configuration;
        public AutenticateService(IConfiguration configuration)
        {
            _configuration=configuration;
            connectionString = @"Data Source=DESKTOP-7E97UIH;Initial Catalog=BookMyShow;Integrated Security=True";
        }

        private string connectionString;
     
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

      


    public string Authenticate(string userEmail, string password)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT UserEmail,Password FROM UserInfo";
               
                dbConnection.Open();
                var id1 = dbConnection.Query<Contact>(sQuery);
                var s2 = id1.ToList();
                // var id2 = id.ToList();
               
            if(!s2.Any(x=> x.UserEmail.Equals(userEmail) && x.Password.Equals(password)))
               return null;






                var key = _configuration.GetValue<string>("JwtConfig:Key");
                var keyBytes = Encoding.ASCII.GetBytes(key);

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,userEmail)
                    }),

                    Expires = DateTime.UtcNow.AddDays(6),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
                    }
        
    }
}
