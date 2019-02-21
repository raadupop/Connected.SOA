using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts;
using Connected.Accounts.Domain.Accounts.Dto;

namespace Connected.Accounts.Data
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly AccountsDbContext _accountsDbContext;

        public MembershipRepository(AccountsDbContext accountsDbContext)
        {
            _accountsDbContext = accountsDbContext;
        }

        public bool IsUserAlreadyRegistered(string email)
        {
            return _accountsDbContext.Users.SingleOrDefault(u => u.Email == email) != null;
        }

        public async Task CreateApplicationUser(UserAccountDto userAccountDto)
        {
            _accountsDbContext.Add(userAccountDto);
            await _accountsDbContext.SaveChangesAsync();
        }

        public List<UserAccountDto> GetAllUsers()
        {
            return _accountsDbContext.Users.ToList();
        }

        public async Task DeleteUser(UserAccountDto userToBeRemoved)
        {
            _accountsDbContext.Users.Remove(userToBeRemoved);
            await _accountsDbContext.SaveChangesAsync();
        }

        public UserAccountDto FindUserById(int userId)
        {
            return _accountsDbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public async Task UpdateUserAccoutInformation(UserAccountDto userAccountDto)
        {
            _accountsDbContext.Entry(userAccountDto).CurrentValues.SetValues(userAccountDto);
            await _accountsDbContext.SaveChangesAsync();
        }
    }
}
