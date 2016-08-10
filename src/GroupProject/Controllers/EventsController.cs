using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Data;
using GroupProject.Services;

namespace GroupProject.Controllers
{
    [Route ("api/[controller]")]

    public class EventsController : Controller
    {
        private EventService _eventService;
        private CategoryService _categoryService;
           
        
        public EventsController(EventService es, CategoryService cs) {
            _eventService = es;
            _categoryService = cs;
        }

        [HttpGet]
        public IList<EventDTO>GetAllEvents() {
            return _eventService.GetAllEvents();

        }

        // GET /api/event/{id}
        [HttpGet("{eventId}")]
        public EventDTO GetEventById(int eventId) {

            return _eventService.GetEventById(eventId);
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
