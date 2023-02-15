using WebAppMVC.Models.Entities;

namespace WebAppMVC.Models.MockData
{
    public class MockData
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Id = 1, Description = "desc1", Name="product x", Price = 20000},
                new Product { Id = 2, Description = "desc2", Name="product y", Price = 30000},
                new Product { Id = 3, Description = "desc3", Name="product z", Price = 40000},
                new Product { Id = 4, Description = "desc4", Name="product w", Price = 50000}
            };
            return products;
        }
    }
}
