using BookMyShowAPI.Model;
using BookMyShowAPI.Services.MovieServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAll();
        }

        [HttpGet("getId/{MovieId}")]
        public Movie Get(int MovieId)
        {
            return _movieService.GetById(MovieId);
        }

        [HttpPost("add")]
        public void Post([FromBody] Movie movie)
        {
            if (ModelState.IsValid)
                _movieService.Add(movie);
        }

        [HttpPut("update/{MovieId}")]
        public void Put(int MovieId, [FromBody] Movie movie)
        {
            movie.movieId = MovieId;
            if (ModelState.IsValid)
                _movieService.update(movie);
        }

        [HttpDelete("delete/{MovieId}")]

        public void Delete(int MovieId)
        {
            _movieService.Delete(MovieId);

        }
    }
}
