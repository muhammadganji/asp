using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.Description)
                .HasColumnName("Descr")
                .HasColumnType("nvarchar(500)");

            builder.HasKey(p => p.Id);

            builder.HasOne<Category>()
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // shadow property
            builder.Property<DateTime>("InsertDate");

            builder.Property(p => p.Createtime)
                .HasDefaultValueSql("getdate()");
            

            // prevent generate value
            //builder.Property(p => p.Id).ValueGeneratedNever();



        }
    }
}
