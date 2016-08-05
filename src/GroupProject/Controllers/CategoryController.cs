using GroupProject.Models;
using GroupProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Services;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]

    public class CategoryController : Controller
    {
        private CategoryService _categoryService;
        public CategoryController(CategoryService cs) {
            _categoryService = cs;
        }

        [HttpGet]
        public IList<CategoryDTO>GetAllCategories() {
            return _categoryService.GetAllCategories();
        }
    }
    
}
