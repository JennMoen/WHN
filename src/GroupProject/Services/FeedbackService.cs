using GroupProject.Data;
using GroupProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class FeedbackService
    {
        private FeedbackRepository _feedbackRepo;
        public FeedbackService(FeedbackRepository fr) {
            _feedbackRepo = fr;
        }

        public IList<FeedbackDTO> GetAllFeedback() {

            return (from f in _feedbackRepo.GetAllFeedback()
                    select new FeedbackDTO() {
                        Id = f.Id,
                        Text = f.Text,
                        EventId = f.EventId,
                        Event = f.Event,
                        UserId = f.UserId,
                        User = f.User
                    }).ToList();
                   
        }
    }
}
