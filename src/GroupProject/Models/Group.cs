using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace GroupProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserGroup> UserGroup { get; set; }
        public IList<EventGroup> EventGroups { get; set; }
    }
}
