using System.ComponentModel.DataAnnotations;

namespace Connected.Authorization.Domain.Auth.ViewModel
{
    public class AuthenticationInputViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
