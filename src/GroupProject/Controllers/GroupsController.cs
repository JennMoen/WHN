using GroupProject.Data;
using GroupProject.Services;
using Microsoft.AspNetCore.Authorization;
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
        private UserGroupService _ugService;

        public GroupsController(GroupService gs, UserGroupService ugs)
        {
            _groupService = gs;
            _ugService = ugs;
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

        [HttpGet("createdgroups")]
        public IList<GroupDTO> GetGroups(string userName)
        {

            return _groupService.GetGroupsByCreatorId(User.Identity.Name);
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
        [Authorize]
        public IActionResult Add([FromBody] int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ugService.AddMember(User.Identity.Name, groupId);
            return Ok();

        }

        [HttpGet("mygroups")]
        public IList<UserGroupDTO> Get(string userName)
        {
            return _ugService.GetGroupsForUser(User.Identity.Name);


        }

       [HttpDelete("mygroups")]
       public IActionResult DeleteUserGroup([FromQuery]int groupId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ugService.DeleteUserGroup(groupId, User.Identity.Name);
            return Ok();
        }

        [HttpPut("{groupId}")]
        public IActionResult EditGroup([FromBody] GroupDTO Group, [FromQuery] int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Group.Id = groupId;
            _groupService.EditGroup(Group, groupId, User.Identity.Name);

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(GroupDTO group, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            group.Id = id;
            _groupService.DeleteGroup(group, User.Identity.Name);

            return Ok();

        }
    }
}
