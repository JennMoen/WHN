using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class EventRepository {
        private ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) {
            _db = db;
        }

        //get all events
        public IQueryable<Event> GetAllEvents() {
            return _db.Events;
        }
    }

}
