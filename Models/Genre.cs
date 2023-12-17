using Microsoft.EntityFrameworkCore;
using System;

namespace MovieApplication
{
    public class Genre
    {
        public int genreId { get; set; }
        public string genreName { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
