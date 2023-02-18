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
    public class OrderConfig: IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            

            // Mamad-2023-02-18-1001
            builder.Property(p => p.OrderNumber)
                .HasComputedColumnSql("'Mamad-' + CAST( Year(getdate()) AS varchar ) + '-' + CAST( MONTH(getdate()) AS varchar ) + '-' + CAST( Day(getdate()) AS varchar ) + '-' + CAST( [Id] AS varchar )");
            
        }
    }

}


/*
 ** :::::::::::  Docment  ::::::::::
 *
 * Year(getdate()): return Int
 * CAST( value ) AS varchar
 * CAST( Year(getdate()) AS varvhar )
 
 
 */
