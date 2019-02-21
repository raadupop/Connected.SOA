using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts.ViewModel;

namespace Connected.Accounts.Domain.Accounts
{
    public interface IMembershipService
    {
        Task CreateNewUserAccount(UserAccountRegistrationViewModel registerUser);

        UserAccountGridViewModel GetAllUsersAccounts();

        Task DeleteUserAccount(int userAccountId);

        Task UpdateUserAccoutInformation(UserAccountViewModel updatedUserAccount);
    }
}
