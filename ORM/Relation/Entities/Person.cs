namespace Entities
{
    public  class Person
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string NationaleCode { get; set; }
        public int temp { get; set; }
        public int? Score { get; set; }
        public ICollection<PersonOrder> PersonOrders { get; set; }



    }
}
