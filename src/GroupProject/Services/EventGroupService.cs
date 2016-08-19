using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class EventGroupService
    {
        private EventGroupRepository _egRepo;
        private EventRepository _eventRepo;
        private GroupRepository _groupRepo;

        public EventGroupService(EventGroupRepository egr, EventRepository er, GroupRepository gr)
        {
            _egRepo = egr;
            _eventRepo = er;
            _groupRepo = gr;
        }

        public void AddEventGroup(EventGroupDTO eventGroup)
        {
            EventGroup dbEventGroup = new EventGroup()
            {
                EventId = _eventRepo.GetEventById(eventGroup.EventId).First().Id,
                GroupId = eventGroup.GroupId

            };

            _egRepo.addEventGroup(dbEventGroup);


        }

        public IList<EventGroupDTO> GetEventsForGroup(int groupId)
        {
            return (from eg in _egRepo.GetGroupEvents(groupId)
                    select new EventGroupDTO()
                    {
                        EventId = eg.Event.Id,
                        EventName = eg.Event.Name,
                        GroupId = eg.Group.Id,
                        GroupName = eg.Group.Name
                    }).ToList();

        }

        public IList<EventGroupDTO> GetGroupsforEvent(int eventId)
        {
            return (from eg in _egRepo.GetGroupsForEvent(eventId)
                    select new EventGroupDTO()
                    {
                        EventId = eg.Event.Id,
                        EventName = eg.Event.Name,
                        GroupId = eg.Group.Id,
                        GroupName = eg.Group.Name

                    }).ToList();

        }

        public void DeleteEventGroup(int eventId, int groupId)
        {
            EventGroup dbEventGroup = _egRepo.GetEventbyGroupId(eventId, groupId).First();

            _egRepo.Delete(dbEventGroup);
        }

    }
}
