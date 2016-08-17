using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class GroupService
    {
        private GroupRepository _groupRepo;
        private UserRepository _uRepo;
        public GroupService(GroupRepository gr, UserRepository ur)
        {
            _groupRepo = gr;
            _uRepo = ur;
        }

        public IList<GroupDTO> GetAllGroups()
        {

            return (from g in _groupRepo.GetAllGroups()
                    select new GroupDTO()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Location = g.Location,
                        Creator = g.Creator.UserName,
                        Description = g.Description,
                        Members = (from u in g.UserGroups
                                   select new UserGroupDTO()
                                   {
                                       UserName = u.User.UserName


                                   }).ToList()
                    }).ToList();
        }


        public void AddGroup(GroupDTO group, string currentUser)
        {

            Group dbGroup = new Group()
            {
                Id = group.Id,
                Name = group.Name,
                Location = group.Location,
                CreatorId = _uRepo.GetUser(currentUser).First().Id,
                Description = group.Description
            };

            _groupRepo.Add(dbGroup);


        }

        //method to add yourself to/join a group
        public void AddMember(string currentUser, int groupId)
        {

            UserGroup dbUserGroup = new UserGroup()
            {
                GroupId = _groupRepo.GetGroupById(groupId).First().Id,
                UserId = _uRepo.GetUser(currentUser).First().Id

            };

            _groupRepo.AddMember(dbUserGroup);
        }


        // Not in use for now--old method used to add members to a group
        //public void AddMember(UserGroupDTO userGroup)
        //{
        //    UserGroup dbUserGroup = new UserGroup()
        //    {
        //        GroupId = userGroup.GroupId,
        //        UserId = _uRepo.GetUser(userGroup.UserName).First().Id

        //    };


        //        _groupRepo.AddMember(dbUserGroup);
        //}

        public GroupDTO GetGroupById(int groupId)
        {
            return (from g in _groupRepo.GetGroupById(groupId)
                    select new GroupDTO()
                    {
                        Name = g.Name,
                        Id = g.Id,
                        Location = g.Location,
                        Creator= g.Creator.UserName,
                        Description = g.Description,
                        Members = (from u in g.UserGroups
                                   select new UserGroupDTO()
                                   {
                                       UserName = u.User.UserName


                                   }).ToList()


                    }).FirstOrDefault();

        }

        public IList<UserGroupDTO> GetGroupsForUser(string currentUser)
        {
            return (from ug in _groupRepo.GetGroupsForUser(currentUser)
                    select new UserGroupDTO()
                    {
                        GroupId= ug.Group.Id,
                        GroupName = ug.Group.Name,
                        UserName= currentUser
                        
                    }).ToList();

        }
    }
}
