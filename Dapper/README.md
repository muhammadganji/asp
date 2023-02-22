# Dapper
یک میکرو ORM با اجرایی سریع که می توان به صورت دستی دستورات کوئری های خاصی رو پیاده سازی نمود.
از دیتابیس های زیر پشتیبانی میکنه.
<br/>
1. SQL Server
2. MySQL
3. Sqlite
4. SqlCE
5. Firebird 


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>مطالب</summary>
  <ol>
    <li>
        <a href="#مقدمه">مقدمه</a>
    </li>
    <li>
      <a href="#دستورات-پایه">دستورات پایه</a>   
    </li>
    <li>
      <a href="#نکات">نکات</a>
    </li>
  </ol>
</details>


![تصویر برنامه](https://github.com/lpln25/asp/blob/main/Dapper/page-6.jpg) <br/> *نمایی از اجرای برنامه ساخته شده با `Dapper`*

<br/>


<!-- مقدمه -->
## مقدمه
1. نصب پکیج
```c#
PM> NuGet\Install-Package Dapper
```
2. دیتابیس با موجودیت `Users` از قبل داریم و در برنامه با نام  `CustomersDto` می شناسیم.

```c#
public class CustomerDto
{
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
```
3. رشته اتصال بین دیتابیس و برنامه

```c#
public readonly string connectionString = @"Data Source=.; User Id=mamad; Password=1234; Initial Catalog=DapperDb; Trusted_Connection=true; TrustServerCertificate=true";
```

4. معماری ریپازیتوری

```c#
public  interface ICustomerRepositories
{
    int Add(CustomerDto customer);
    int Add(List<CustomerDto> customers);
    int Delete(long ids);
    int Delete(List<CustomerDto> customers);
    int Update(CustomerDto customer);
    int Update(List<CustomerDto> customer);
    CustomerDto GetCustomer(long id);
    List<CustomerDto> GetCustomers();
}
```

<br/>
<br/>



## دستورات پایه
دستورات اولیه با معماری MVC
دستورات پایه دیتابیس
<br/>
به صوت نمونه یکی از توابع

```c#
public int Add(List<CustomerDto> customers)
{
    string Sql = "INSERT INTO [dbo].[Users] (Firstname ,Lastname) VALUES (@Firstname, @Lastname)";
    var connenction = new SqlConnection(connectionString);
    var result = connenction.Execute(Sql, customers);
    return result;
}
```

## نکات
1. برای کار با دستورات بایستی کتابخانه `System.Data.SqlClient` نیز نصب شود، چراکه خود Dapper نیز ازین کتابخانه استفاده می نماید.

<!-- Feb 2023 Muhammad Ganji Nezhad-->
