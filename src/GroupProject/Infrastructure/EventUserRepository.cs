using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class EventUserRepository
    {
        private ApplicationDbContext _db;
        public EventUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IQueryable<EventUser> GetEventUserByUserId(int eventId, string userName)
        {
            return from eu in _db.EventUsers
                   where eu.EventId == eventId && eu.User.UserName == userName
                   select eu;
        }

        public void RemoveEventUser(EventUser dbEventUser, string userId)
        {
            _db.EventUsers.Remove(dbEventUser);
            _db.SaveChanges();
        }

        public IQueryable<EventUser> GetAttendeesByEventId(int id)
        {
            return from eu in _db.EventUsers
                   where eu.EventId == id
                   select eu;

        }

    }
}
