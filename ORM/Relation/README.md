# Relationship Entity
ارتباط بین موجودیت ها و پیاده سازی تنظیمات هر یک

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>مطالب</summary>
  <ol>
    <li>
      <a href="#موجودیت-ها">موجودیت ها</a>    
    </li>
    <li>
      <a href="#تنظیمات">تنظیمات</a>
    </li>
    <li>
      <a href="#نکات">نکات</a>
    </li>
  </ol>
</details>


![تصویر دیتابیس و ارتباطات بین جداول](https://github.com/lpln25/asp/blob/main/ORM/Relation/page-3.JPG) <br/> *نمونه دیتابیس پیاده سازی شده با `Entity FrameworkeCore`*

<!-- موجودیت-ها -->
## موجودیت-ها
کلاس های زیر جزو موجودیت های اصلی می باشند.
```c#
public DbSet<Product> Products { get; set; }
public DbSet<Person> Persons { get; set; }
public DbSet<Car> Cars { get; set; }
public DbSet<NotePad> Notepads { get; set; }
public DbSet<Category> Categories { get; set; }
public DbSet<Order> Orders { get; set; }
public DbSet<PersonOrder> PersonOrders { get; set; }
```

<!-- تنظیمات -->
## تنظیمات
تنظیمات زیر برای تمیز نوشتن کلاس ها پیاده سازی شده اند.
```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new ProductConfig());
    modelBuilder.ApplyConfiguration(new PersonConfig());
    modelBuilder.ApplyConfiguration(new NotePadConfig());
    modelBuilder.ApplyConfiguration(new CategoryConfig());
    modelBuilder.ApplyConfiguration(new OrderConfig());
}
```

نمونه تنظیمات یکی از موجودیت ها:
```c#
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
```

## نکات
1. ارتباط بین جداول از طریق تنظیمات پیاده سازی شده
2. فهمیدن فیلد کلید خارجی از طریق `Convention` های EF core  می باشد.
