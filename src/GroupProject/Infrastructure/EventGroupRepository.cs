using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class EventGroupRepository
    {
        private ApplicationDbContext _db;
        public EventGroupRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        //groups can attend an event
        public void addEventGroup(EventGroup eventGroup)
        {
            if ((from eg in _db.EventGroups
                 where eg.EventId == eventGroup.EventId
                 && eg.GroupId == eventGroup.GroupId
                 select eg).FirstOrDefault() == null)

            {
                _db.EventGroups.Add(eventGroup);
                _db.SaveChanges();

            }

        }

        //grab all events for a certain group
        public IQueryable<EventGroup> GetGroupEvents(int groupId)
        {
            return from eg in _db.EventGroups
                   where eg.Group.Id == groupId
                   select eg;

        }

    }
}
