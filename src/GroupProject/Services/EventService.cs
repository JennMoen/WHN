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
        public EventService(EventRepository er)
        {
            _eventRepo = er;
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