﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Infrastructure;

namespace GroupProject.Services
{
    public class EventService
    {
        private EventRepository _eventRepo;
        public EventService(EventRepository er) {
            _eventRepo = er;
        }

        // get a list of all events
        public IList<EventDTO> GetAllEvents() {

            return (from e in _eventRepo.GetAllEventsByUserId()

                    select new EventDTO() {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,

                        Status = e.Status,
                        Location = e.Location,
                        AdmissionPrice = e.AdmissionPrice,
                        ImageUrl = e.ImageUrl,
                        CategoryId = e.CategoryId,
<<<<<<< HEAD
                        Category = e.Category,

                        UserId = e.UserId,
                        Creator = e.Creator,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,

                        Attendees = e.Attendees,
                        Feedback = e.Feedback,
                        EventGroups = e.EventGroups
                    }).ToList();

        }


        // get a list of all events by User ID
        public IList<EventDTO> GetAllEventsByUserId() {

            return (from e in _eventRepo.GetAllEventsByUserId()

                    select new EventDTO() {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,

                        Status = e.Status,
                        Location = e.Location,
                        AdmissionPrice = e.AdmissionPrice,
                        ImageUrl = e.ImageUrl,
                        CategoryId = e.CategoryId,
=======
>>>>>>> 0b8c0784e8a04ad1ad72d742824cde0fd1adf949
                        Category = e.Category,

                        UserId = e.UserId,
                        Creator = e.Creator,
                        DateCreated = e.DateCreated,
                        DateOfEvent = e.DateOfEvent,
                        EndTime = e.EndTime,

                        Attendees = e.Attendees,
                        Feedback = e.Feedback,
                        EventGroups = e.EventGroups
                    }).ToList();

        }
    }
}
