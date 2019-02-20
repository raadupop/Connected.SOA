using System.ComponentModel.DataAnnotations;

namespace Connected.Auth.Domain.Auth.ViewModel
{
    public class AuthenticationViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
