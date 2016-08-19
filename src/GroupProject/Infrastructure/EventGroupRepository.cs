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

        //grab groups for a certain event
        public IQueryable<EventGroup> GetGroupsForEvent(int eventId)
        {
            return from eg in _db.EventGroups
                   where eg.Event.Id == eventId
                   select eg;

        }

        //singles out one particular eventGroupfor deletion
        public IQueryable<EventGroup> GetEventbyGroupId(int eventId, int groupId)
        {
            return from eg in _db.EventGroups
                   where eg.GroupId == groupId && eg.EventId == eventId
                   select eg;
        }


        //deletes eventGroup, i.e. a group no longer wants to attend an event
        public void Delete(EventGroup dbEventGroup)
        {
            _db.EventGroups.Remove(dbEventGroup);
            _db.SaveChanges();

        }
    }
}
