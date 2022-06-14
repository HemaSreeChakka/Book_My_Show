using System.ComponentModel.DataAnnotations;

namespace BookMyShowAPI.Model
{
    public class Movie
    {
        [Key]
        public int movieId { get; set; }

        public string movieName { get; set; } = string.Empty;

        public DateTime movieDate { get; set; } 

        public string movieGenre { get; set; } = string.Empty;

        public string movieLanguage { get; set; } = string.Empty;
        public string movieDescription { get; set; } = string.Empty;
        public string movieRating { get; set; } = string.Empty;
    }
}
