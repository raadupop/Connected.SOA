using Connected.Authorization.Domain.Auth;
using Connected.Authorization.Domain.Auth.Dto;
using System.Linq;

namespace Connected.Authorization.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AuthorizationDbContext _authorizationDbContext;

        public UsersRepository(AuthorizationDbContext dbContext)
        {
            _authorizationDbContext = dbContext;
        }

        public UserIdentity GetUserMatchedgBy(string email, string password)
        {
            return _authorizationDbContext.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
