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

        //get single event by its id

        public IQueryable<Event> GetEventById(int id)
        {
            return from e in _db.Events
                   where e.Id == id
                   select e;
        }



        //get all events that a user created
        public IQueryable<Event> GetAllEventsByUserId(string id)
        {
            return from e in _db.Events
                   where e.CreatorId == id
                   select e;
        }

        public void Add(Event dbEvent)
        {
            _db.Events.Add(dbEvent);
            _db.SaveChanges();
        }
      
        public void AddEventUsers(EventUser attendee) {

         

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

