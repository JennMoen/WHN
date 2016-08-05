﻿using GroupProject.Data;
using GroupProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class GroupService
    {
        private GroupRepository _groupRepo;
        public GroupService(GroupRepository gr) {
            _groupRepo = gr;
        }

        public IList<GroupDTO> GetAllGroups() {

            return (from g in _groupRepo.GetAllGroups()
                    select new GroupDTO() {
                        Id = g.Id,
                        Name = g.Name,
                        UserGroups = g.UserGroups,
                        EventGroups = g.EventGroups
                    }).ToList();
        }
    }
}
