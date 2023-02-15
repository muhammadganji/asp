using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models.Entities;

namespace WebAppMVC.Models
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
