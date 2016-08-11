<<<<<<< HEAD
﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Data;
using GroupProject.Services;
using Microsoft.AspNetCore.Authorization;

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
=======
﻿//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using GroupProject.Data;
//using GroupProject.Services;

//namespace GroupProject.Controllers
//{
//    [Route("api/[controller]")]

//    public class EventsController : Controller
//    {
//        private EventService _eventService;
//        private CategoryService _categoryService;


//        public EventsController(EventService es, CategoryService cs)
//        {
//            _eventService = es;
//            _categoryService = cs;
//        }

//        [HttpGet]
//        public IList<EventDTO> GetAllEvents()
//        {
//            return _eventService.GetAllEvents();

//        }
>>>>>>> 2d6acc1008d7a944c83f0515d1cc74c19922cdc0

//        // GET /api/event/{id}

//        [HttpGet("{id}")]
//        public IList<EventDTO> GetAllEventsByUserId(string Id)
//        {
//        }

//        [HttpGet("{eventId}")]
//        public EventDTO GetEventById(int eventId) {


<<<<<<< HEAD
        [HttpPost]
        [Authorize]
        public IActionResult PostEvents([FromBody] EventDTO Event)
        {
=======
//            return _eventService.GetEventById(eventId);
//        }

//        [HttpPost]
//        public IActionResult PostEvents([FromBody] EventDTO Event)
//        {

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }



//            _eventService.CreateEvent(Event, User.Identity.Name);
        

//            return Ok();
//        }
//        [HttpDelete]
//        public IActionResult DeleteEvent([FromBody] EventDTO Event)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
>>>>>>> 2d6acc1008d7a944c83f0515d1cc74c19922cdc0


//            _eventService.DeleteEvent(Event, User.Identity.Name);


//            return Ok();
//        }

//        [HttpPost("{id}/attend")]
//        public IActionResult Add(int eventId, string user) {

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _eventService.AddEventUser(User.Identity.Name, eventId);


//            return Ok();


//        }
//    }
//}
