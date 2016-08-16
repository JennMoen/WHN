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
                    }).ToList();
        }


        public void AddGroup(GroupDTO group)
        {

            Group dbGroup = new Group()
            {
                Id = group.Id,
                Name = group.Name

            };

            _groupRepo.Add(dbGroup);


        }

        //public void AddMember(string user, int groupId)
        //{

        //    UserGroup dbUserGroup = new UserGroup()
        //    {
        //        GroupId = _groupRepo.GetGroupById(groupId).First().Id,
        //        UserId = _uRepo.GetUser(user).First().Id

        //    };

        //    _groupRepo.AddMember(dbUserGroup);
        //}

            public void AddMember(UserGroupDTO userGroup)
        {
            UserGroup dbUserGroup = new UserGroup()
            {
                GroupId = userGroup.GroupId,
                UserId = userGroup.UserName

            };

            _groupRepo.AddMember(dbUserGroup);

        }



        public GroupDTO GetGroupById(int groupId) {

            return (from g in _groupRepo.GetGroupById(groupId)
                    select new GroupDTO()
                    {
                        Name= g.Name,
                        Id=g.Id
                      


                    }).FirstOrDefault();


        }
    }
}
