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

        public IQueryable<Category> GetCategoryByName(string catName)
        {
            return from c in _db.Categories
                   where c.Name == catName
                   select c;
                
        }

        public IQueryable<string> GetCategoryImageUrlById(int catId)
        {
            return from c in _db.Categories
                   where c.Id == catId
                   select c.ImageUrl;
        }

    }
}
