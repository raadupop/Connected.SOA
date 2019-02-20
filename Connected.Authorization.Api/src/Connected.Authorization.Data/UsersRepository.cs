using Connected.Authorization.Domain.Auth;
using Connected.Authorization.Domain.Auth.Dto;

namespace Connected.Authorization.Data
{
    public class UsersRepository : IUsersRepository
    {
        public UserIdentity GetUserMatchedgBy(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
