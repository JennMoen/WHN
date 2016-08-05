using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
 
    public class FeedbackRepository
    {

        private ApplicationDbContext _db;
        public FeedbackRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Feedback> GetAllFeedback() {
            return _db.Feedback;
        }
    }
}
