using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class UserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {

            _db = db;
        }


        //gets all user names so a user can select them to invite to an event or add to a group
        public IQueryable<ApplicationUser> GetAllUserNames()
        {

            return from u in _db.Users
                   select u;

        }

    }
}
