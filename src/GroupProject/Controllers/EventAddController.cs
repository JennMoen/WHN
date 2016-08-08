using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Data;
using GroupProject.Services;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]

    public class EventAddController
    {
        private CategoryService _categoryService;
        public EventAddController(CategoryService cs) {
            _categoryService = cs;
        }

        [HttpGet]
        public IList<CategoryDTO> GetAllCategories() {
            return _categoryService.GetAllCategories();

        }
    }
}
