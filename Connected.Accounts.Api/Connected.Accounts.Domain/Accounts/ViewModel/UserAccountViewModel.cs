using System;
using System.ComponentModel.DataAnnotations;

namespace Connected.Accounts.Domain.Accounts.ViewModel
{
    public class UserAccountViewModel 
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
