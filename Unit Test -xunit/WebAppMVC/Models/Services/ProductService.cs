using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAppMVC.Models.Entities;

namespace WebAppMVC.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _context;
        public ProductService(DataBaseContext context)
        {
            _context = context;
        }

        public int ProductCount
        {
            get => _context.Products.Count();
            set => ProductCount = value;
        }
        public IBrandService Brand
        {
            get => Brand;
            set => Brand = value;
        }

        public Product Add(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id) ?? new Product();
        }

        public int GetProductPrice(int Id)
        {
            return _context.Products.Where(p => p.Id == Id).FirstOrDefault().Price;
        }

        public void GetProductPrice(int Id, out int price)
        {
            price = 1000;
        }

        public void Remove(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        int IProductService.GetPriceProtected(int Id)
        {
            return 10000;
        }
    }
}
