using System.Collections.Generic;
using BLL.Dtos.Customer;

namespace BLL.Services
{
    public interface ICustomerService
    {
        CustomerDto GetCustomerById(int customerId);
        List<CustomerDto> GetAllCustomers();
        List<CustomerDto> GetCustomersByName(string name);
        void UpdateCustomer(CustomerDto dto);
    }
}
