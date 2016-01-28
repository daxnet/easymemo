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
    public class MemoEntityConfiguration : EntityTypeConfiguration<Memo>
    {
        public MemoEntityConfiguration()
        {
            ToTable("Memos");
            HasKey(x => x.ID);
            Property(x => x.ID).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Content).IsUnicode()
                .IsRequired()
                .IsMaxLength()
                .IsUnicode();
            Property(x => x.DateAdded)
                .IsRequired();
            Property(x => x.DateModified)
                .IsOptional();
            Property(x => x.Title).IsUnicode()
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
