using BookMyShowAPI.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShowAPI.Services.MovieServices
{
    public class MovieService:IMovieService
    {
        private string connectionString;
        public MovieService()
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
      
      

        public void Delete(int MovieId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM MovieInfo WHERE MovieId=@MovieId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { MovieId = MovieId });
            }
        }

        public void Add(Movie movie)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MovieInfo(movieName,movieGenre,movieLanguage,movieDescription, movieRating,movieDate) VALUES(@movieName,@movieGenre,@movieLanguage,@movieDescription,@movieRating,@movieDate)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, movie);
            }
        }

        public void update(Movie movie)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE MovieInfo SET movieName=@movieName,movieGenre=@movieGenre,movieLanguage=@movieLanguage,movieDescription=@movieDescription,movieRating=@movieRating,movieDate=@movieDate  WHERE MovieId=@MovieId";
                dbConnection.Open();
                dbConnection.Query(sQuery, movie);
            }
        }

        IEnumerable<Movie> IMovieService.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT movieName FROM MovieInfo";
                dbConnection.Open();
              var id= dbConnection.Query<Movie>(sQuery).ToList();
                return id;
            }
        }

        Movie IMovieService.GetById(int MovieId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM MovieInfo WHERE MovieId=@MovieId";
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Movie>(sQuery, new { MovieId = MovieId });
            }
        }
    }
}
