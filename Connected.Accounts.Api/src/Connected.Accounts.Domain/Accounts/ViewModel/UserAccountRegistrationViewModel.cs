using System.ComponentModel.DataAnnotations;

namespace Connected.Accounts.Domain.Accounts.ViewModel
{
    public class UserAccountRegistrationViewModel
    {
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
