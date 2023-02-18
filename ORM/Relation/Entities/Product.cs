using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        // به صورت اتوماتیک تشخیص میده که کلید خارجی هستش 
        public long CategoryId { get; set; }
        // به صورت اتوماتیک توسط دیتابیس مقدار دهی میشه
        public DateTime Createtime { get; set; }


    }

}
