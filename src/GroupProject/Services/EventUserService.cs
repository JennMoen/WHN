using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class EventUserService
    {
        private EventRepository _eventRepo;
        private UserRepository _uRepo;
        private EventUserRepository _euRepo;

        public EventUserService(EventUserRepository eur, EventRepository er, UserRepository ur)
        {
            _eventRepo = er;
            _uRepo = ur;
            _euRepo = eur;
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

        public void DeleteEventUser(int eventId, string userName)
        {
            EventUser dbEventUser = _euRepo.GetEventUserByUserId(eventId, userName).First();

            _euRepo.RemoveEventUser(dbEventUser, userName);
        }
        public IList<EventUserDTO> GetEventsForUser(string currentUser)
        {

            return (from eu in _eventRepo.GetEventsForUser(currentUser)
                    select new EventUserDTO()
                    {
                        EventId = eu.Event.Id,
                        UserName = eu.User.UserName,
                        EventName = eu.Event.Name,
                        //NumGoing = eu.User.UserName.Count(),
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
                            CreatorName = eu.Event.Creator.UserName,
                            //Attendees = (from a in eu.Event.Attendees
                            //             select new EventUserDTO()
                            //             {
                            //                 UserName = a.User.UserName
                            //             }).ToList(),
                            //NumGoing = eu.Event.Attendees.Count()
                        }
                    }).ToList();

        }
    }
}
