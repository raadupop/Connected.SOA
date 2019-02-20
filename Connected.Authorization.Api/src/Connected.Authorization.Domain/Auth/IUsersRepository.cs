using Connected.Authorization.Domain.Auth.Dto;

namespace Connected.Authorization.Domain.Auth
{
    public interface IUsersRepository
    {
        UserIdentity GetUserMatchedgBy(string email, string password);
    }
}
