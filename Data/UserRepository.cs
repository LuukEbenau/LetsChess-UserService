using LetsChess_UserService.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef_AuthService.Data
{
    public class UserRepository
    {
        readonly DBCauth authenticationContext;
        public UserRepository(DBCauth auth)
        {
            authenticationContext = auth;
        }
        public User GetUserById(string userId)
        {
            return authenticationContext.Users.FirstOrDefault(u => u.ExternalId == userId);
        }

        public User AddUser(User user)
        {
            var entry = authenticationContext.Users.Add(user);
            authenticationContext.SaveChanges();

            return entry.Entity;
        }
    }
 
}
