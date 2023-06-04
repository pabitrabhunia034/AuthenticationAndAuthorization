using AutheNAutho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutheNAutho.DB
{
    public class UserDB
    {
        public List<UserModel> UserList()
        {
            return new List<UserModel>
            {
                new UserModel {Id=1,Name="Pabitra Bhunia",Email="pabitra@gmail.com",Password="123"},
                new UserModel {Id=2,Name="Sanjib Dolai",Email="sanjib@gmail.com",Password="1234"},
                new UserModel {Id=3,Name="Suva Samanta",Email="suva@gmail.com",Password="12345"},
                new UserModel {Id=4,Name="Kaustav Gupta",Email="kaustav@gmail.com",Password="123456"}
            };
        }
        public List<RoleModel> RoleList()
        {
            return new List<RoleModel>
            {
                new RoleModel {UserId=1,RoleName="Super Admin"},
                new RoleModel {UserId=2,RoleName="Admin"},
                new RoleModel {UserId=3,RoleName="User"},
                new RoleModel {UserId=4,RoleName="User"},
                
            };
        }
    }
}