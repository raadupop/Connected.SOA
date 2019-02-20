using Connected.Auth.Domain.Auth.ViewModel;
using Connected.Authorization.Domain.Auth;

namespace Connected.Authorization.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenManager _tokenManager;

        public AuthenticationService(IUsersRepository usersRepository, ITokenManager tokenManager)
        {
            _usersRepository = usersRepository;
            _tokenManager = tokenManager;
        }

        public AuthenticationResultViewModel GetAuthenticationResult(string email, string password)
        {
            var userIdentity = _usersRepository.GetUserMatchedgBy(email, password);

            if (userIdentity != null)
            {
                return new AuthenticationResultViewModel()
                {
                    AuthorizationToken = _tokenManager.GenerateToken(userIdentity),
                    UserId = userIdentity.Id
                };
            }

            return null;
        }
    }
}
