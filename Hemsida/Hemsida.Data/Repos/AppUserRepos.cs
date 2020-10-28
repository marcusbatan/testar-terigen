﻿using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class AppUserRepos
    {
        public UserInfo AddUserInfo(string userId, string userName, string firstName, string lastName, int age)
        {
            using (var db = new HemsidaEntities())
            {
                var addInfo = new UserInfo
                {
                    id = Guid.NewGuid(),
                    userId = userId,
                    userName = userName,
                    firstName = firstName,
                    lastName = lastName,
                    age = age
                };
                db.UserInfo.Add(addInfo);
                db.SaveChanges();
                return addInfo;
            }
        }
        public UserInfo GetUser(string id)
        {
            using (var db = new HemsidaEntities())
            {
                var user = db.UserInfo.Where(u => u.userId == id).FirstOrDefault();
                return user;
            }
        }
        public List<UserInfo> ListUsers(string search)
        {
            using (var db = new HemsidaEntities())
            {
                return db.UserInfo.Where(u => u.userName.Contains(search)).ToList();
            }
        }
    }
}