using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;

namespace GroupProject.Services
{
    public class EventService
    {
        private EventRepository _eventRepo;
        private UserRepository _uRepo;

        public EventService(EventRepository er, UserRepository ur)
        {
            _eventRepo = er;
            _uRepo = ur;
        }

        // get a list of all events
        public IList<EventDTO> GetAllEvents()
        {

            return (from e in _eventRepo.GetAllEvents()

                    select new EventDTO()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Status = e.Status,
                        Location = e.Location,
                        AdmissionPrice = e.AdmissionPrice,
                        ImageUrl = e.ImageUrl,
                        Category = e.Category,
                        CreatorName = e.Creator.UserName,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,
                        //Attendees = e.Attendees, // (from a in e.Attendees select new EventUserDTO(){ ... }).ToList()
                        // Feedback = e.Feedback    // Same here

                    }).ToList();


        }
        public IList<EventDTO> GetAllEventsByUserId(string Id)
        {
            return (from e in _eventRepo.GetAllEventsByUserId(Id)
                    select new EventDTO()
                    {
                        Name = e.Name,
                        Description = e.Description,
                        Status = e.Status,
                        Location = e.Location,
                        AdmissionPrice = e.AdmissionPrice,
                        ImageUrl = e.ImageUrl,
                        Category = e.Category,
                        CreatorName = e.Creator.Id,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,
                        // Attendees = e.Attendees,
                        //Feedback = e.Feedback,

                    }).ToList();
        }


<<<<<<< HEAD
=======

>>>>>>> 461bf52299efacada956bc14ae45f841175125fd
        public EventDTO GetEventById(int eventId)
        {
            return (from e in _eventRepo.GetEventById(eventId)
                    select new EventDTO()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,

                        Status = e.Status,
                        Location = e.Location,
                        AdmissionPrice = e.AdmissionPrice,
                        ImageUrl = e.ImageUrl,

                        Category = e.Category,


<<<<<<< HEAD
                        CreatorName = e.Creator.UserName,
=======
                        //CreatorName = e.CreatorName,
>>>>>>> 461bf52299efacada956bc14ae45f841175125fd
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,

                        //Attendees = e.Attendees,
                        //Feedback = e.Feedback,

                    }).FirstOrDefault();
        }
<<<<<<< HEAD
=======




>>>>>>> 461bf52299efacada956bc14ae45f841175125fd


        public void CreateEvent(EventDTO Event, string currentUser)

        {
            Event dbEvent = new Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Status = Event.Status,
                ImageUrl = Event.ImageUrl,
                //Feedback = Event.Feedback,
                EndTime = Event.EndTime,
                Description = Event.Description,
                DateOfEvent = Event.DateOfEvent,
                DateCreated = Event.DateCreated,
                Location = Event.Location,
                CategoryId = Event.Category.Id,
                AdmissionPrice = Event.AdmissionPrice,
                Category = Event.Category,
                CreatorId = _uRepo.GetUser(currentUser).First().Id
            };
            _eventRepo.Add(dbEvent);

        }

        public void AddEventUser(string currentUser, int eventId)
        {
            EventUser dbEventUser = new EventUser()
            {
                //get an error statement here saying "sequence returns no results"
                EventId = _eventRepo.GetEventById(eventId).First().Id,
                UserId = _uRepo.GetUser(currentUser).First().Id
            };

            _eventRepo.AddEventUsers(dbEventUser);
        }





        public void DeleteEvent(EventDTO EventInfo, string Username)
        {
            Event dbEvent = new Event()
            {
                Name = EventInfo.Name,
                Status = EventInfo.Status,
                ImageUrl = EventInfo.ImageUrl,
                //Feedback = EventInfo.Feedback,
                EndTime = EventInfo.EndTime,
                Description = EventInfo.Description,
                DateOfEvent = EventInfo.DateOfEvent,
                DateCreated = EventInfo.DateCreated,
                //Creator = EventInfo.Creator,
                Category = EventInfo.Category,
                AdmissionPrice = EventInfo.AdmissionPrice,

                //Id = EventInfo.Id
            };

            _eventRepo.Remove(dbEvent);
        }

    }
}



