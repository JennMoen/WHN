using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Data;
using GroupProject.Services;

namespace GroupProject.Controllers
{
    [Route ("api/[controller]")]

    public class EventController : Controller
    {
        private EventService _eventService;
        public EventController(EventService es) {
            _eventService = es;
        }

        [HttpGet]
        public IList<EventDTO>GetAllEvents() {
            return _eventService.GetAllEvents();

        }

        // GET /api/event/{id}
        [HttpGet("{id}")]
        public IList<EventDTO>GetAllEventsByUserId(int Id) {

            return _eventService.GetAllEventsByUserId(Id);
        }

        [HttpPost]
        public IActionResult PostEvents([FromBody] EventDTO Event)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            _eventService.AddEvent(Event, User.Identity.Name);


            return Ok();
    }
        [HttpDelete]
        public IActionResult DeleteEvent([FromBody] EventDTO Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventService.DeleteEvent(Event, User.Identity.Name);


            return Ok();
        }
    
    }
    }
