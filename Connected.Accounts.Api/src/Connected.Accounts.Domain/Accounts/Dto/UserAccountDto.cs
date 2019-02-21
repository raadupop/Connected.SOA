using System;
using System.ComponentModel.DataAnnotations;
using Connected.Accounts.Domain.Abstract;

namespace Connected.Accounts.Domain.Accounts.Dto
{
    public class UserAccountDto : EntityBase
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [Required]
        public string Password { get; set; }

        public int? AccessFailedCount { get; set; }

        public bool IsActive { get; set; }
    }
}
