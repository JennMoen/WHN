using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Infrastructure
{
    public class CategoryRepository
    {

        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Category> GetAllCategories() {
            return _db.Categories;
        }

    }
}
