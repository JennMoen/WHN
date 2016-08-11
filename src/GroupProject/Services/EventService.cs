﻿using System;
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
        public IList<EventDTO> GetAllEventsByCreatorId(string Id)
        {
            return (from e in _eventRepo.GetAllEventsByCreatorId(Id)
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
<<<<<<< HEAD
=======
                //Category = Event.Category,
>>>>>>> 39f00a763a093f37c74d969181da2caa33dcf8f5
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
                        
                        Events = new EventDTO()
                        {
                            Name = eu.Event.Name

        }
                        

                        
                    }).ToList();

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



