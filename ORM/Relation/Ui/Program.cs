// See https://aka.ms/new-console-template for more information

using DAL;
using Entities;

DatabaseContext context = new DatabaseContext();

// هیچ وقت از این دستور در محیط های عملیاتی استفاده نکنیم
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Category c = new Category()
{
    CategoryName = "cat1"
};

Product product = new Product()
{
    Name = "product1",
    CategoryId = 1,
    Price = 100,
};

// Shadow property
context.Entry(product).Property("InsertDate").CurrentValue = DateTime.Now;
context.SaveChanges();
context.Categories.Add(c);
context.Products.Add(product);
context.SaveChanges();

Person person = new Person()
{
    FirstName = "Sina",
    LastName = "Abadi",
    NationaleCode = "10203040",
};
context.Persons.Add(person);
context.SaveChanges();




