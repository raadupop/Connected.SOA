using System.Collections.Generic;
using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts.Dto;

namespace Connected.Accounts.Domain.Accounts
{
    public interface IMembershipRepository
    {
        bool IsUserAlreadyRegistered(string email);

        Task CreateApplicationUser(UserAccountDto userDto);

        List<UserAccountDto> GetAllUsers();

        Task DeleteUser(UserAccountDto user);

        UserAccountDto FindUserById(int userId);

        Task UpdateUserAccoutInformation(UserAccountDto userDto);
    }
}
