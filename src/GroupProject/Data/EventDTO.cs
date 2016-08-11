using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Data
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public decimal AdmissionPrice { get; set; }
        public string ImageUrl { get; set; }

       
        public Category Category { get; set; }

        
        //public ApplicationUser Creator { get; set; } Needs to be a string for his/her name, convert to AppUser at Service level
        public string CreatorName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateOfEvent { get; set; }
        public DateTime EndTime { get; set; }

        public IList<EventUserDTO> Attendees { get; set; }  // Turn into IList<EventUserDTO>
        public IList<FeedbackDTO> Feedback { get; set; }    // Turn into IList<FeedbackDTO>
       
    }
}
