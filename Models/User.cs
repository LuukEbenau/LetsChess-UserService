using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChess_UserService.Models
{
	public class User
	{
		[Key, NotNull, Required]
		public string ExternalId { get; set; }
		[NotNull, MaxLength(100)]
		public string Username { get; set; }
		[AllowNull]
		public string ImageUrl { get; set; }
	}
}
