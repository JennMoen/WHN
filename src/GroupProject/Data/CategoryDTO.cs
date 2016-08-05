using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Data
{
    public class CategoryDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Event> Events { get; set; }
    }
}
