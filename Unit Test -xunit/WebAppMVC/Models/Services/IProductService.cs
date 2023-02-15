using WebAppMVC.Models.Entities;

namespace WebAppMVC.Models.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Add(Product product);
        void Update(Product product);
        Product GetById(int id);
        void Remove(int id);

        // ::::: UnitTest.cs :::::::::
        int GetProductPrice(int Id);
        void GetProductPrice(int Id, out int price);
        int ProductCount { get; set; }
        protected int GetPriceProtected(int Id);

        // :::: For Chain Moq Multiple Service
        IBrandService Brand { get; set; }
    }
}
