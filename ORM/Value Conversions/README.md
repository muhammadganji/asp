<style>
p,h1,h2,h3,h4,h5,ul,details{
direction: rtl;
}
</style>



# Relationship Entity
برای خوانایی بهتر مقادیر Enum در دیتابیس و همینطور داده های بولین و دیگر مقادیر که به صورت کد گذاری شده در دیتابیس نگهداری میشود، خوانایی آن به صورت مستقیم مشکل بود و همینطور حفظ محرمانگی داده های مشتریان و فروش، در سرورهای اشتراکی، میتوان از این رویکرد برنامه `Ef Core Value Conversions` بهره مند شویم.


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>مطالب</summary>
  <ol>
    <li>
        <a href="#موجودیت-ها">موجودیت ها</a>
    </li>
    <li>
      <a href="#تبدیل-داده-ها">تبدیل داده ها</a>   
    </li>
    <li>
      <a href="#نکات">نکات</a>
    </li>
  </ol>
</details>


![تصویر دیتابیس و جداول](https://github.com/lpln25/asp/blob/main/ORM/Value%20Conversions/page-5.jpg) <br/> *نمونه دیتابیس پیاده سازی شده با `EF Core Value Conversion`*

<br/>


<!-- موجودیت-ها -->
## موجودیت ها
کلاس های زیر جزو موجودیت های اصلی می باشند.
```c#
public DbSet<Person> Persons { get; set; }
public DbSet<Order> Orders { get; set; }
```
### فیلدهای کلاس سفارش و وضعیت فروش و مشتری
```c#
public  class Person
{
    public long Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Order> Orders { get; set; }
}

public class Order
{
    public long Id { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public bool Done { get; set; }
    public long PersonId { get; set; }
}

public enum OrderStatus
{
    Processing,
    Sent,
    Delivered
}

```

<!-- تبدیل داده ها -->
## تبدیل داده ها
تنظیمات برای تبدیل داده های `enum` و `bool` و کدگذاری داده های مشتری
```c#
public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var enumToString = new ValueConverter<OrderStatus, string>(p => p.ToString()
            , p => (OrderStatus)Enum.Parse(typeof(OrderStatus), p));

            var boolToString = new BoolToStringConverter("No", "Yes");

            // :::::::

            builder.Property(p => p.OrderStatus)
                .HasConversion(enumToString);

            builder.Property(p => p.Done)
                .HasConversion(boolToString);
        }
    }
```

### نگهداری داده های ارزشمند به شیوه ی کد گذاری
```c#
public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Email)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));

            builder.Property(p => p.PhoneNumber)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));
        }

        public static string Base64Encode(string painText)
        {
            var painTextBytes = System.Text.Encoding.UTF8.GetBytes(painText);
            return System.Convert.ToBase64String(painTextBytes);
        }

        public static string Base64Decode(string base64EncodeedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodeedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
```

## نکات
1. نگهداری به صورت نمادین می باشد و لزومی در پیاده سازی داده ها `enum`  و `bool` نیست، چراکه یک سرباری بر روی سیستم ایجاد کرده ایم که به شیوه ی اتوماتیک این رویه رو انجام میدهد.
2. برای پیاده سازی تابع کد گذاری بایستی در لایه ی دسترسی به دیتابیس `Data Access Layer` این کار انجام دهیم.
3. بایستی از روش های قویتری برای کدگذاری مشخصات مشتری استفاده نماییم تا دسترسی به اطلاعات فروش مشتری های ما برای افراد هکر و دیتابیس ادمین‌های سرورهای اشتراکی قابل فهم نباشد.


<!-- Feb 2023 Muhammad Ganji Nezhad-->
