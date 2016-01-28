using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMemo.Domain.Model;

namespace EasyMemo.Repositories
{
    public class AccountEntityConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountEntityConfiguration()
        {
            ToTable("Accounts");
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DateCreated).IsRequired();
            Property(x => x.DateLastLogon).IsOptional();
            Property(x => x.DisplayName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(32);
            Property(x => x.Email)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
            Property(x => x.IsDeleted).IsOptional();
            Property(x => x.Name).IsRequired()
                .IsUnicode()
                .HasMaxLength(16);
            Property(x => x.Password).IsRequired()
                .IsUnicode()
                .HasMaxLength(4096);
        }
    }
}
