using System.Collections.Generic;
using System.Linq;
using BLL.Dtos.Customer;
using DAL.Infrastructure;

namespace BLL.Services
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository)
        {
            repository = _repository;
        }
        public CustomerDto GetCustomerById(int customerId)
        {
            return repository.Get(m => m.Id == customerId).ToCustomerDto();
        }

        public List<CustomerDto> GetAllCustomers()
        {
            return repository.All().ToList().ToCustomerDtos();
        }

        public List<CustomerDto> GetCustomersByName(string name)
        {
            return repository.Find(m => m.Name.StartsWith(name)).ToList().ToCustomerDtos();
        }

        public void UpdateCustomer(CustomerDto dto)
        {
            repository.Update(dto.ToCustomer());
        }
    }
}
