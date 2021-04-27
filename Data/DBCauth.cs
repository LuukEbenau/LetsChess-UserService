using LetsChess_UserService.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef_AuthService.Data
{
    public class DBCauth : DbContext
    {
        public DBCauth(DbContextOptions<DBCauth> options) : base(options)
        {
			Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
    }
}
