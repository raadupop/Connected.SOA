using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts.ViewModel;

namespace Connected.Accounts.Domain.Accounts
{
    public interface IMembershipService
    {
        Task CreateNewUser(UserAccountRegistrationViewModel registerUser);

        UserAccountGridViewModel GetAllUsersAccounts();

        Task DeleteUserAsync(int userId);

        Task UpdateUserAccoutInformation(UserAccountViewModel userModified);
    }
}
