using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Data
{
    public class EventUserDTO
    {
        public string UserName { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public IList<EventUserDTO> Attendees { get; set; }
        public int NumGoing { get; set; }
        public EventDTO Events { get; set; }
    }
}
