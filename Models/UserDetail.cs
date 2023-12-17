using System;
using Microsoft.EntityFrameworkCore;

namespace MovieApplication
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; } 
    }
}
