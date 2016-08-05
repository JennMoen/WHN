using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class GroupRepository
    {
        private ApplicationDbContext _db;
        public GroupRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Group> GetAllGroups() {
            return _db.Groups;
        }
    }
}
