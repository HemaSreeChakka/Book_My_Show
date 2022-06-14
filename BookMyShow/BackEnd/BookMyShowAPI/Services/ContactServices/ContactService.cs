using BookMyShowAPI.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShowAPI.Services.ContactServices
{
    public class ContactService:IContactService
    {
        private string connectionString;
        public ContactService()
        {
            connectionString = @"Data Source=DESKTOP-7E97UIH;Initial Catalog=BookMyShow;Integrated Security=True";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

      

        public void Add(Contact user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO UserInfo(UserName,UserEmail,UserMobile,Password,ConfirmPassword) VALUES(@UserName,@UserEmail,@UserMobile,@Password,@ConfirmPassword)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }
        }

        public void Delete(int UserId)
        {
            throw new NotImplementedException();
        }

        public void update(Contact user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE UserInfo SET UserName=@UserName,UserEmail=@UserEmail,UserMobile=@UserMobile,Password=@Password,ConfirmPassword=@ConfirmPassword  WHERE UserId=@UserId";
                dbConnection.Open();
                dbConnection.Query(sQuery, user);
            }
        }

        IEnumerable<Contact> IContactService.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM UserInfo";
                dbConnection.Open();
                return dbConnection.Query<Contact>(sQuery);
            }
        }

        Contact IContactService.GetById(int UserId)
        {
            using (IDbConnection dbConnection= Connection)
            {
                string squery = @"SELECT * FROM UserInfo WHERE UserId=UserId";
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Contact>(squery,new { UserId=UserId});
            }
          
        }

          
    }
}
