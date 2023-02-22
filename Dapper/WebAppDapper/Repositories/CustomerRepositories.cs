using System.Data.SqlClient;
using Dapper;

namespace Repositories
{
    public class CustomerRepositories: ICustomerRepositories
    {
        public readonly string connectionString = @"Data Source=.; User Id=mamad; Password=1234; Initial Catalog=DapperDb; Trusted_Connection=true; TrustServerCertificate=true";
        public int Add(CustomerDto customer)
        {

            string Sql = "INSERT INTO [dbo].[Users] (Firstname ,Lastname) VALUES (@Firstname, @Lastname)";
            var connenction = new SqlConnection(connectionString);
            var result = connenction.Execute(Sql, new { Firstname = customer.Firstname, Lastname = customer.Lastname });

            return result;
        }

        public int Add(List<CustomerDto> customers)
        {

            string Sql = "INSERT INTO [dbo].[Users] (Firstname ,Lastname) VALUES (@Firstname, @Lastname)";
            var connenction = new SqlConnection(connectionString);
            var result = connenction.Execute(Sql, customers);

            return result;
        }

        public int Delete(long id)
        {
            string sql = "Delete Users where Id=@Id";
            var connection = new SqlConnection(connectionString);
            var result = connection.Execute(sql,new { Id = id });
            return result;
        }

        public int Delete(List<CustomerDto> customers)
        {
            string sql = "Delete Users where Id=@Id";
            var connection = new SqlConnection(connectionString);
            var result = connection.Execute(sql, customers);
            return result;
        }

        public int Update(CustomerDto customer)
        {
            string sql = "UPDATE Users SET Firstname=@Firstname, Lastname=@Lastname WHERE Id=@Id";
            var connection= new SqlConnection(connectionString);
            var result = connection.Execute(sql, new { Firstname = customer.Firstname, Lastname = customer.Lastname, Id = customer.Id });
            return result;
        }
        public int Update(List<CustomerDto> customers)
        {
            string sql = "UPDATE Users SET Firstname=@Firstname, Lastname=@Lastname WHERE Id=@Id";
            var connection = new SqlConnection(connectionString);
            var result = connection.Execute(sql, customers);
            return result;
        }

        public CustomerDto GetCustomer(long id)
        {
            string sql = "SELECT * FROM Users WHERE Id=@Id";
            using (var connection = new SqlConnection(connectionString))
            {
                var customer = connection.QueryFirstOrDefault<CustomerDto>(sql,new {Id = id});
                return customer;
            }
        }

        public List<CustomerDto> GetCustomers()
        {
            string sql = "SELECT * FROM Users";
            using (var connection = new SqlConnection(connectionString))
            {
                var customers = connection.Query<CustomerDto>(sql).ToList();
                return customers;
            }
        }
    }
}
