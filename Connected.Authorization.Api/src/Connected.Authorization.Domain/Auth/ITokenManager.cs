using Connected.Authorization.Domain.Auth.Dto;

namespace Connected.Authorization.Domain.Auth
{
    public interface ITokenManager
    {
        string GenerateToken(UserIdentity user);
    }
}
