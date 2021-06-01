using LetsChess_UserService.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MinDef_AuthService.Data;

using System;

namespace LetsChess_UserService.Controllers
{
	[ApiController]
	[Route("/user")]
	public class UserController : Controller
	{
		private readonly ILogger<UserController> logger;
		private readonly UserRepository userRepository;

		public UserController(UserRepository userRepository, ILogger<UserController> logger)
		{
			this.userRepository = userRepository;
			this.logger = logger;
		}

		[HttpPost("register")]
		public IActionResult Register(User user) {
			logger.LogDebug($"/user/register endpoint called with user {user?.ExternalId}",user);
			try
			{
				var dbUser = userRepository.GetUserById(user.ExternalId);

				if (dbUser == default)
				{
					logger.LogDebug($"no user found with id {user?.ExternalId}, adding a new user");
					return Ok(userRepository.AddUser(user));
				}
				else
				{
					logger.LogTrace($"user {dbUser.Username} found with id {user?.ExternalId}");
					return Ok(dbUser);
				}
			}
			catch (Exception e) {
				logger.LogError(e, $"An error has occured while calling /user/register: '{e.Message}'");
				throw;
			}
		}
	}
}
