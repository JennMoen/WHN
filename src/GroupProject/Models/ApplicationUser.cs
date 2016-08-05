using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupProject.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser

    {

        public IList<Event> Events { get; set; }
        public IList<UserGroup> UserGroups { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MetropolitanArea { get; set; }
        public IList<Feedback> Feedback { get; set; }

    }
}
