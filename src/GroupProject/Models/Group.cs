using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserGroup> UserGroups { get; set; }
        public IList<EventGroup> EventGroups { get; set; }



        
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
    }
}
