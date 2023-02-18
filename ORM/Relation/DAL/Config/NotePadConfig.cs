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
    public class NotePadConfig : IEntityTypeConfiguration<NotePad>
    {
        public void Configure(EntityTypeBuilder<NotePad> builder)
        {
            builder.HasNoKey();
        }
    }
}
