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

    public class GroupsController : Controller
    {
        private GroupService _groupService;
        public GroupsController(GroupService gs)
        {
            _groupService = gs;
        }


        [HttpGet]
        public IList<GroupDTO> GetAllGroups()
        {
            return _groupService.GetAllGroups();
        }

        [HttpPost]
        public IActionResult Add([FromBody] GroupDTO group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _groupService.AddGroup(group);

            return Ok();

        }
    }
}
