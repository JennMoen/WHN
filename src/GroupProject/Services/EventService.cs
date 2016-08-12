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


        public IList<EventDTO> GetEventsByCreatorId(string Id)
        {
            return (from e in _eventRepo.GetEventsByCreatorId(Id)
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
                        CreatorName = e.Creator.UserName,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,
                        //Attendees = e.Attendees,
                        //Feedback = e.Feedback,
                    }).FirstOrDefault();
        }


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
                //Category = Event.Category,
                CreatorId = _uRepo.GetUser(currentUser).First().Id
            };
            _eventRepo.Add(dbEvent);

        }

        public void AddEventUser(string currentUser, int eventId)
        {
            EventUser dbEventUser = new EventUser()
            {
                EventId = _eventRepo.GetEventById(eventId).First().Id,
                UserId = _uRepo.GetUser(currentUser).First().Id
            };

            _eventRepo.AddEventUsers(dbEventUser);
        }


        public IList<EventUserDTO> GetEventsForUser(string currentUser)
        {

            return (from eu in _eventRepo.GetEventsForUser(currentUser)
                    select new EventUserDTO()
                    {
                        EventId = eu.Event.Id,
                        UserName = eu.User.UserName,
                        EventName = eu.Event.Name,

                        Events = new EventDTO()
                        {
                            Id = eu.Event.Id,
                            Name = eu.Event.Name,
                            Description = eu.Event.Description,
                            Status = eu.Event.Status,
                            Location = eu.Event.Location,
                            AdmissionPrice = eu.Event.AdmissionPrice,
                            ImageUrl = eu.Event.ImageUrl,
                            Category = eu.Event.Category,
                            DateCreated = eu.Event.DateCreated,
                            DateOfEvent = eu.Event.DateOfEvent,
                            EndTime = eu.Event.EndTime,
                            CreatorName = eu.Event.Creator.UserName

                        }

                    }).ToList();

        }

        public void UpdateEvent(EventDTO Event, string id)
        {
            Event dbEvent = _eventRepo.GetEventById(Event.Id).First();

            _eventRepo.SaveUpdate(dbEvent);
        }

        public void DeleteEvent(EventDTO Event, string currentUser)
        {

            _eventRepo.Remove(_eventRepo.GetEventById(Event.Id).First(), currentUser);


            //Event dbEvent = new Event()
            //{
            //    Name = EventInfo.Name,
            //    Status = EventInfo.Status,
            //    ImageUrl = EventInfo.ImageUrl,
            //    //Feedback = EventInfo.Feedback,
            //    EndTime = EventInfo.EndTime,
            //    Description = EventInfo.Description,
            //    DateOfEvent = EventInfo.DateOfEvent,
            //    DateCreated = EventInfo.DateCreated,
            //    //Creator = EventInfo.Creator,
            //    Category = EventInfo.Category,
            //    AdmissionPrice = EventInfo.AdmissionPrice,

            //    //Id = EventInfo.Id
            //};

            //_eventRepo.Remove(dbEvent);
        }

    }
}



