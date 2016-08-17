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
                EventId = eventGroup.EventId,
                GroupId = eventGroup.GroupId
            };

            _egRepo.addEventGroup(dbEventGroup);


        }
    }
}
