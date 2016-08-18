using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class GroupRepository
    {
        private ApplicationDbContext _db;
        public GroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //get all groups
        public IQueryable<Group> GetAllGroups()
        {
            return _db.Groups;
        }

        //get a single group by its id
        public IQueryable<Group> GetGroupById(int id)
        {
            return from g in _db.Groups
                   where g.Id == id
                   select g;
        }

        //duh, add a group  :)
        public void Add(Group group)
        {
            _db.Groups.Add(group);
            _db.SaveChanges();
        }

        //user can add him/herself to a group
        public void AddMember(UserGroup member)
        {

            if ((from ug in _db.UserGroups
                 where ug.GroupId == member.GroupId
                    && ug.UserId == member.UserId
                 select ug).FirstOrDefault() == null)
            {

                _db.UserGroups.Add(member);
                _db.SaveChanges();
            }

        }

        

        //get all groups that a user created
        public IQueryable<Group> GetGroupsByCreatorId(string id)
        {
            return from g in _db.Groups
                   where g.Creator.UserName == id
                   select g;

        }

    }

}



