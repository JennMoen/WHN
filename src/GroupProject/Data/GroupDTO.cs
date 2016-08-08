using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Data
{
    public class GroupDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserGroup> UserGroups { get; set; }
        public IList<EventGroup> EventGroups { get; set; }
        
    }
}
