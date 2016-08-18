using GroupProject.Data;
using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Infrastructure
{
    public class UserGroupRepository
    {
        private ApplicationDbContext _db;
        public UserGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

       

        //gets all groups from userGroups table that match a single userId
        public IQueryable<UserGroup> GetGroupsForUser(string id)
        {

            return from ug in _db.UserGroups
                   where ug.User.UserName == id
                   select ug;


        }

        //grabs unique userGroup pair for deletion
        public IQueryable<UserGroup> GetUserGroupbyUserId(int groupId, string userName)
        {
            return from ug in _db.UserGroups
                   where ug.GroupId == groupId && ug.User.UserName == userName
                   select ug;

        }


        //leave a group/delete user from userGroup table for an group
        public void RemoveUserGroup(UserGroup dbUserGroup, string userId)
        {
            _db.UserGroups.Remove(dbUserGroup);
            _db.SaveChanges();

        }


    }
}
