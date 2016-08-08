using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroupProject.Services;
using GroupProject.Data;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserService _uService;
        public UserController(UserService us) {
            _uService = us;
        }

        [HttpGet]
        public IList<UserDTO> GetUserNames() {

            return _uService.GetUserNames();
        }
    }
}
