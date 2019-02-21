using System.Collections.Generic;

namespace Connected.Accounts.Domain.Accounts.ViewModel
{
    public class UserAccountGridViewModel
    {
        public List<UserAccountViewModel> UserAccounts { get; set; }

        public int PageNumber { get; set; }
    }
}
