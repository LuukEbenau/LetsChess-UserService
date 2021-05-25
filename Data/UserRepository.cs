using LetsChess_UserService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef_AuthService.Data
{
    public class UserRepository
    {
        readonly DBCauth authenticationContext;
		private readonly ILogger<UserRepository> logger;

		public UserRepository(DBCauth auth, ILogger<UserRepository> logger)
        {
            authenticationContext = auth;
			this.logger = logger;
		}
        public User GetUserById(string userId)
        {
            return authenticationContext.Users.FirstOrDefault(u => u.ExternalId == userId);
        }

        public User AddUser(User user)
        {
            var entry = authenticationContext.Users.Add(user);
            authenticationContext.SaveChanges();
            logger.LogInformation($"User added with id {entry.Entity.ExternalId}");
            return entry.Entity;
        }
    }
 
}
