using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace GroupProject.Models
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Event> Events { get; set; }
    }
}
