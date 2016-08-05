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
        public IQueryable<Event> GetAllEventsByUserId() {
            return _db.Events;
        }

        //get all events by userid
        public IQueryable<Event> GetAllEventsByUserid (int Id) {
            return from e in _db.Events
                   where e.Id == Id
                   orderby e.DateOfEvent
                   select e;
        }
    }

}
