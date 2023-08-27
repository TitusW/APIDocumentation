using System;
using System.ComponentModel.DataAnnotations;

namespace APIService.Models
{
	public class User
	{
		[Key]
		public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
	}
}

