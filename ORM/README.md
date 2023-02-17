# رویکرد DataBaseFirst
در مواقعی که یک دیتابیس از قبل پیاده سازی شده و نیازمند توسعه آن هستیم. برای استخراج جداول آن و پیاده سازی به صورت مدل از روش `DataBase First` استفاده میکنیم.

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>مطالب</summary>
  <ol>
    <li>
      <a href="#استخراج-مدل">مقدمه و کتابخونه ها</a>    
    </li>
    <li>
      <a href="#رشته-اتصال">رشته اتصال</a>
    </li>
    <li>
      <a href="#نکات">نکات</a>
    </li>
  </ol>
</details>


![تصویر اجرای دستور](page-2.jpg) <br/> *تصویر نمونه اجرای دستور فراخوانی از DataBaseFirst .*

<!-- استخراج-مدل -->
## استخراج مدل
دیتابیس از قبل ایجاد شده و بایستی معماری جداول آن را در پروژه دلخواه پیاده سازی کنیم.
کتابخونه های لازم:
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
```

<!-- رشته اتصال -->
## رشته اتصال
دستوری که باید در ناگت پکیج فراخوانی کنیم:
```
Scaffold-DbContext [-Connection] [-Provider] [-OutputDir] [-Context] [-Schemas>] [-Tables>] [-DataAnnotations] [-Force] [-Project] [-StartupProject] [<CommonParameters>]
```

 مثال از سرویس دهنده sqlserver:
```
Scaffold-DbContext "Data Source=.; User Id=####; Password=####; Initial Catalog=TestDataBaseFirst; TrustServerCertificate=true; Trusted_Connection=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

## نکات
1. پوشه `Models` از قبل بایستی در پروژه ایجاد شده باشد.
2. نام کاربری فوق بایستی اجازه ی دسترسی به دیتابیس فوق را داشته باشد.




