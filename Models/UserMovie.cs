using Microsoft.EntityFrameworkCore;
using System;
namespace MovieApplication
{
    public class UserMovie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public decimal Rating { get; set; }
        public long RatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}