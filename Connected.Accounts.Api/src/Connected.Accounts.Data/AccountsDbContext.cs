using Connected.Accounts.Domain.Accounts.Dto;
using Microsoft.EntityFrameworkCore;

namespace Connected.Accounts.Data
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<UserAccountDto> Users { get; set; }
    }
}
