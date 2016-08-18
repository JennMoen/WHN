using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Services;
using GroupProject.Data;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class EventGroupsController : Controller
    {
        private EventGroupService _eGroupService;
        public EventGroupsController(EventGroupService egs)
        {
            _eGroupService = egs;

        }


        [HttpPost("{groupId}/attend")]
        public IActionResult Add(int groupId, [FromBody]int eventId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EventGroupDTO egd = new EventGroupDTO()
            {
                EventId = eventId,
                GroupId = groupId
            };

            _eGroupService.AddEventGroup(egd);
            return Ok();


        }

        [HttpGet("{groupId}/groupevents")]
        public IList<EventGroupDTO> GetGroupEvents(int groupId)
        {
            return _eGroupService.GetEventsForGroup(groupId);

        }

        [HttpGet("{eventId}/groupsattending")]
        public IList<EventGroupDTO> GetGroupsforEvent(int eventId)
        {
            return _eGroupService.GetGroupsforEvent(eventId);

        }
    }
}
