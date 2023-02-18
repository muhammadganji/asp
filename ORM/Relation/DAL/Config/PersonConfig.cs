using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace DAL.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("tbl_Person",schema:"info");
            

            builder.HasAlternateKey(p => p.NationaleCode);
            builder.Property(p=>p.NationaleCode).IsRequired();

            // Ignor to add To DataBase [NotMapped]
            builder.Ignore(p => p.temp);

            builder.Property(p => p.Score)
                .HasDefaultValue(100);

            builder.Property(p => p.FullName)
                .HasComputedColumnSql("[FirstName] + ' '+ [LastName]");


        }
    }
}
