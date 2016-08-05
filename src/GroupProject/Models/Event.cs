using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public decimal AdmissionPrice { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateOfEvent { get; set; }
        public DateTime EndTime { get; set; }
        
        public IList<EventUser> Attendees { get; set; }
        public IList<Feedback> Feedback { get; set; }
        public IList<EventGroup> EventGroups { get; set; }




    }
}
