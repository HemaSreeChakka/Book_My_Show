using BookMyShowAPI.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShowAPI.Services.TicketServices
{
    public class TicketService:ITicketService
    {
        private string connectionString;
        public TicketService()
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

        public int Add(Ticket ticket)
        {
            using (IDbConnection dbConnection = Connection)
            {
            
       
                dbConnection.Open();
                var id = dbConnection.QuerySingle<int>(@"
                INSERT INTO TicketInfo (transactionMode,transactionStatus,seats,totalCost,bookingDate) 
                VALUES  (@transactionMode, @transactionStatus, @seats, @totalCost, @bookingDate);
                SELECT CAST(SCOPE_IDENTITY() as int)",
                new { @transactionMode = ticket.transactionMode, 
                    @transactionStatus = ticket.transactionStatus, @seats = ticket.seats,
                    @totalCost = ticket.totalCost, @bookingDate = ticket.bookingDate });
                
                return id;
            }
        }
       
        public void Delete(int ticketId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM TicketInfo WHERE ticketId=@ticketId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ticketId = ticketId });
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM TicketInfo";
                dbConnection.Open();
                return dbConnection.Query<Ticket>(sQuery);
            }
        }

        public Ticket GetById(int ticketId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM TicketInfo WHERE ticketId=@ticketId";
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Ticket>(sQuery, new { ticketId = ticketId });
            }
        }
    }
}
