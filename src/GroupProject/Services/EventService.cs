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

                        
                        Creator = e.Creator,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,

                        Attendees = e.Attendees,
                        Feedback = e.Feedback,

                    }).ToList();


        }
        public IList<EventDTO> GetAllEventsByUserId(int Id)
        {
            return (from e in _eventRepo.GetAllEventsByUserId(Id)
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

                        
                        Creator = e.Creator,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,

                        Attendees = e.Attendees,
                        Feedback = e.Feedback,

                    }).ToList();
        }


        public void AddEvent(EventDTO EventInfo, string currentUser)
        {
            Event dbEvent = new Event()
            {
                Name = EventInfo.Name,
                Status = EventInfo.Status,
                ImageUrl = EventInfo.ImageUrl,
                Feedback = EventInfo.Feedback,
                EndTime = EventInfo.EndTime,
                Description = EventInfo.Description,
                DateOfEvent = EventInfo.DateOfEvent,
                DateCreated = EventInfo.DateCreated,

                Creator = EventInfo.Creator,
                Category = EventInfo.Category,
                AdmissionPrice = EventInfo.AdmissionPrice,

                Id = EventInfo.Id,

                Location = EventInfo.Location,
                CategoryId = EventInfo.Category.Id,
              //  AdmissionPrice = EventInfo.AdmissionPrice
                //UserId = EventInfo.Creator.Id             Works when Creator field isn't used; need to fix;


            };
            _eventRepo.Add(dbEvent);

            var dbEvents = _eventRepo.GetAllEvents();

            _eventRepo.AddEventUsers((from e in dbEvents
                                     select new EventUser()
                                     {
                                         EventId = e.Id,
                                         UserId = _uRepo.GetUser(currentUser).First().Id

                                     }).FirstOrDefault());
                                   
        }

        public void DeleteEvent(EventDTO EventInfo, string Username)
        {
            Event dbEvent = new Event()
            {
                Name = EventInfo.Name,
                Status = EventInfo.Status,
                ImageUrl = EventInfo.ImageUrl,
                Feedback = EventInfo.Feedback,
                EndTime = EventInfo.EndTime,
                Description = EventInfo.Description,
                DateOfEvent = EventInfo.DateOfEvent,
                DateCreated = EventInfo.DateCreated,
                Creator = EventInfo.Creator,
                Category = EventInfo.Category,
                AdmissionPrice = EventInfo.AdmissionPrice,

                Id = EventInfo.Id
            };

            _eventRepo.Remove(dbEvent);
        }

    }
}



