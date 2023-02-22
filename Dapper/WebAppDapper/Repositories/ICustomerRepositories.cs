using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
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
}
