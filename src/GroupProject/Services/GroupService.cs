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


        public IList<GroupDTO> GetGroupsByCreatorId(string Id)
        {
            return (from g in _groupRepo.GetGroupsByCreatorId(Id)
                    select new GroupDTO()
                    {
                        Id=g.Id,
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

        
    }
}
