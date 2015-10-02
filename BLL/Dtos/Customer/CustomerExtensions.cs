using System.Collections.Generic;
using System.Linq;

namespace BLL.Dtos.Customer
{
    public static class CustomerExtensions
    {
        public static CustomerDto ToCustomerDto(this DAL.Entities.Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name
            };
        }

        public static DAL.Entities.Customer ToCustomer(this CustomerDto customerDto)
        {
            return new DAL.Entities.Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name
            };
        }
        public static List<CustomerDto> ToCustomerDtos(this List<DAL.Entities.Customer> customers)
        {
            return customers.Select(customer => new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name
            }).ToList();
        }

        public static List<DAL.Entities.Customer> ToCustomers(this List<CustomerDto> customerDtos)
        {
            return customerDtos.Select(customer => new DAL.Entities.Customer
            {
                Id = customer.Id,
                Name = customer.Name
            }).ToList();
        }
    }
}
