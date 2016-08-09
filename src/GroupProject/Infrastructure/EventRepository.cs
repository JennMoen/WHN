using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class EventRepository
    {
        private ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        //get all events
        public IQueryable<Event> GetAllEvents()
        {
            return from e in _db.Events
                   orderby e.DateOfEvent descending
                   select e;
        }

        //get all events by userid
        public IQueryable<Event> GetAllEventsByUserId(int Id)
        {
            return from e in _db.Events
                   where e.Id == Id
                   orderby e.DateOfEvent descending
                   select e;
        }

        public void Add(Event dbEvent)
        {
            _db.Events.Add(dbEvent);
            _db.SaveChanges();
        }

        public void AddEventUsers (EventUser attendee) {

            _db.EventUsers.Add(attendee);
            _db.SaveChanges();

        }
        public void Remove(Event dbEvent)
        {
            _db.Events.Remove(dbEvent);
            _db.SaveChanges();
        }
    }

}

