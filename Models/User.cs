using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieApplication
{
    public class User
    {
        public int UserId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string OccupationName { get; set; } // Renamed from Occupation
        public string ZipCode { get; set; }
        public int OccupationId { get; set; } // Foreign key


        public virtual UserDetail? UserDetail { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual ICollection<UserMovie> UserMovies { get; set; }

        public void Display()
        {
            Console.WriteLine($"User ID: {UserId}, Occupation: {Occupation?.OccupationName}");
        }
    }
}
