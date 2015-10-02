using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Infrastructure.EF;

namespace DAL.Infrastructure
{
    public class CustomerRepository:RepositoryBase<Customer>,ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
