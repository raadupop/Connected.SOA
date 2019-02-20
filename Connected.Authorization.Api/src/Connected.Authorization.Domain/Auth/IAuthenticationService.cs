using Connected.Auth.Domain.Auth.ViewModel;

namespace Connected.Authorization.Domain.Auth
{
    public interface IAuthenticationService
    {
        AuthenticationResultViewModel GetAuthenticationResult(string email, string password);
    }
}
