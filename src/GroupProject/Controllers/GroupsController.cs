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

            _groupService.AddGroup(group, User.Identity.Name);

            return Ok();

        }

        [HttpGet("{id}")]
        public GroupDTO GetGroupById(int id)
        {
            return _groupService.GetGroupById(id);
        }


        //not in use for now--controller for adding members to your group
        //[HttpPost("{groupId}/members")]
        //public IActionResult Add(int groupId, [FromBody]string member)
        //{
        //    //if (member == null) return BadRequest("You fucked up");

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    UserGroupDTO ugd = new UserGroupDTO()
        //    {
        //        GroupId = groupId,
        //        UserName = member
        //    };

        //    _groupService.AddMember(ugd);

        //    return Ok();
        //}

        [HttpPost("join")]
        public IActionResult Add([FromBody] int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _groupService.AddMember(User.Identity.Name, groupId);
            return Ok();

        }

        [HttpGet("mygroups")]
        public IList<UserGroupDTO> Get(string userName)
        {
            return _groupService.GetGroupsForUser(User.Identity.Name);


        }

       


    }
}
