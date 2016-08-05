using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Infrastructure;

namespace GroupProject.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepo;
        public CategoryService(CategoryRepository cr) {
            _categoryRepo = cr;
        }

        // get a list of all categories
        public IList<CategoryDTO> GetAllCategories() {

            return (from c in _categoryRepo.GetAllCategories()
                    select new CategoryDTO() {
                        Id = c.Id,
                        Name = c.Name,
                        Events = c.Events
                    }).ToList();
        }
    }
}
