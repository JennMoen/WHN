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
        public IList<UserGroupDTO> Members { get; set; }
        public string Creator { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        
    }
}
