using System.Data.Entity;
using EasyMemo.Domain.Model;

namespace EasyMemo.Repositories
{
    public class EasyMemoContext : DbContext
    {
        public EasyMemoContext()
            : base("EasyMemoDB")
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Memo> Memos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountEntityConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            modelBuilder.Configurations.Add(new MemoEntityConfiguration());
        }
    }
}
