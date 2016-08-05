using GroupProject.Data;
using GroupProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]

    public class GroupController : Controller
    {
        private GroupService _groupService;
        public GroupController(GroupService gs) {
            _groupService = gs;
        }


        [HttpGet]
        public IList<GroupDTO> GetAllGroups() {
            return _groupService.GetAllGroups();
        }
    }
}
