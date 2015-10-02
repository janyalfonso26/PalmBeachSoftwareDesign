using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Infrastructure.EF;

namespace DAL.Infrastructure
{
    public interface IExpenseRepository:IRepository<Expense>
    {
    }
}
