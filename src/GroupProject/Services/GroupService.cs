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
        public GroupService(GroupRepository gr)
        {
            _groupRepo = gr;
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


    }
}
