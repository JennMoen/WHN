using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;
using System.Net.Mail;
using SendGrid;
using System.Net;
using System.Net.Mime;

namespace GroupProject.Services
{
    public class EventService
    {
        private EventRepository _eventRepo;
        private UserRepository _uRepo;
        private EmailService _emailService;
        private CategoryRepository _catRepo;
        private EventUserRepository _euRepo;


        public EventService(EventRepository er, UserRepository ur, EmailService es, CategoryRepository cr, EventUserRepository eur)
        {
            _eventRepo = er;
            _uRepo = ur;
            _emailService = es;
            _catRepo = cr;
            _euRepo = eur;
        
            
           
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
                        Id = e.Id,
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
                    }).FirstOrDefault();
        }

        public void CreateEvent(EventDTO Event, string currentUser)
        {
            Event dbEvent = new Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Status = Event.Status,
                ImageUrl = _catRepo.GetCategoryImageUrlById(Event.Category.Id).First(),
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


            try
            {
                //string sgUsername = "robseals13";
                //string sgPassword = "hughey1398SMU";


                var user = _uRepo.GetUser(currentUser).First();
                List<string> to = new List<string>();
                List<string> toNames = new List<string>();

                to.Add(user.Email);
                toNames.Add(user.UserName);

                _emailService.SendMessage(to.ToArray(), toNames.ToArray(), Startup.AdminEmailAddress, "WHN Admin",
                    Event.Name + " Created",
                    "Your event, " + Event.Name + ", has been successfully created.\n\nBest regards,\nWHN Team");
                //var myMessage = new SendGrid();

                


                //var credentials = new NetworkCredential(sgUsername, sgPassword);

                //var transportWeb = new Web(credentials);

                //// Send the email.
                //transportWeb.Deliver(myMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        public void DeleteEventUser(int eventId, string userName)
        {
           EventUser dbEventUser =  _euRepo.GetEventUserByUserId(eventId, userName).First();

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

        public void UpdateEvent(EventDTO Event, int id)
        {
            //Event dbEvent = _eventRepo.GetEventById(id).FirstOrDefault();
            Event dbEvent = new Event()
            {
                Id = Event.Id,
                Category = Event.Category,
                Name = Event.Name,
                Location = Event.Location,
                AdmissionPrice = Event.AdmissionPrice,
                DateOfEvent = Event.DateOfEvent,
                EndTime = Event.EndTime,
                Description = Event.Description,
                ImageUrl = _catRepo.GetCategoryImageUrlById(Event.Category.Id).First(),
                Status = Event.Status,
                CreatorId = _eventRepo.GetEventByCreatorName(Event.CreatorName).First()
            };


            _eventRepo.SaveUpdate(dbEvent);
        }

        public void DeleteEvent(EventDTO Event, string currentUser)
        {

            _eventRepo.Remove(_eventRepo.GetEventById(Event.Id).First(), currentUser);

        }

    }
}



