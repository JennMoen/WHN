using GroupProject.Data;
using GroupProject.Infrastructure;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class UserGroupService
    {

        private GroupRepository _groupRepo;
        private UserRepository _uRepo;
        private UserGroupRepository _ugRepo;

        public UserGroupService(GroupRepository gr, UserRepository ur, UserGroupRepository ugr)
        {
            _groupRepo = gr;
            _uRepo = ur;
            _ugRepo = ugr;
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


        public IList<UserGroupDTO> GetGroupsForUser(string currentUser)
        {
            return (from ug in _ugRepo.GetGroupsForUser(currentUser)
                    select new UserGroupDTO()
                    {
                        GroupId = ug.Group.Id,
                        GroupName = ug.Group.Name,
                        UserName = currentUser

                    }).ToList();

        }

        public void DeleteUserGroup(int groupId, string userName)
        {

            UserGroup dbUserGroup = _ugRepo.GetUserGroupbyUserId(groupId, userName).First();

            _ugRepo.RemoveUserGroup(dbUserGroup, userName);

        }
    }
}
