using BookMyShowAPI.Model;

namespace BookMyShowAPI.Services.MovieServices
{
    public interface IMovieService
    {
        void Add(Movie movie);
        void update(Movie movie);
        IEnumerable<Movie> GetAll();
        Movie GetById(int MovieId);
        void Delete(int MovieId);
    }
}
