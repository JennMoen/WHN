using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Data;
using GroupProject.Services;
using Microsoft.AspNetCore.Authorization;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]

    public class EventsController : Controller
    {
        private EventService _eventService;
        private CategoryService _categoryService;

        public EventsController(EventService es, CategoryService cs)
        {
            _eventService = es;
            _categoryService = cs;
        }


        [HttpGet]
        public IList<EventDTO> GetAllEvents()
        {
            return _eventService.GetAllEvents();

        }

        [HttpGet("{eventId}")]
        public EventDTO GetEventById(int eventId)
        {
            return _eventService.GetEventById(eventId);
        }


        [HttpPost]
        [Authorize]
        public IActionResult PostEvents([FromBody] EventDTO Event)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventService.CreateEvent(Event, User.Identity.Name);


            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(EventDTO Event, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Event.Id = id;
            _eventService.DeleteEvent(Event, User.Identity.Name);


            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateEvent([FromBody] EventDTO Event, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Event.Id = id;
            _eventService.UpdateEvent(Event, User.Identity.Name);

            return Ok();
        }


        [HttpPost("attend")]
        public IActionResult Add([FromBody] int eventId)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventService.AddEventUser(User.Identity.Name, eventId);

            return Ok();
        }


        [HttpGet("myevents")]
        public IList<EventUserDTO> Get(string userName)
        {

            return _eventService.GetEventsForUser(User.Identity.Name);


        }
        [HttpGet("mycreatedevents")]
        public IList<EventDTO> GetEvents(string userName)
        {

            return _eventService.GetEventsByCreatorId(User.Identity.Name);

        }

    }
}
