using Connected.Authorization.Domain.Auth.Dto;
using Microsoft.EntityFrameworkCore;

namespace Connected.Authorization.Data
{
    public class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> optionBuilder) : base(optionBuilder)
        {
        }

        public DbSet<UserIdentity> Users { get; set; }
    }
}
