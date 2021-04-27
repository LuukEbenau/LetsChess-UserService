using LetsChess_UserService.Models;

using Microsoft.AspNetCore.Mvc;

using MinDef_AuthService.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChess_UserService.Controllers
{
	[ApiController]
	[Route("/api/user")]
	public class UserController : Controller
	{
		private UserRepository userRepository;

		public UserController(DBCauth dBCauth)
		{
			this.userRepository = new UserRepository(dBCauth);
		}

		[HttpPost("register")]
		public IActionResult Register(User user) {
			var dbUser = userRepository.GetUserById(user.ExternalId);
			return dbUser == default ? Ok(userRepository.AddUser(user)) : Ok(dbUser);
		}
	}
}
