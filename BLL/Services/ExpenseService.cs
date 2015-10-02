using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Customer;
using BLL.Dtos.Expense;
using DAL.Entities;
using DAL.Infrastructure;

namespace BLL.Services
{
    class ExpenseService:IExpenseService
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseService(IExpenseRepository _expenseRepository)
        {
            expenseRepository = _expenseRepository;
        }

        public void AddExpense(ExpenseDto expense)
        {
            expenseRepository.Add(expense.ToExpense());
        }

        public void UpdateExpense(ExpenseDto expense)
        {
            expenseRepository.Update(expense.ToExpense());
        }

        public void RemoveExpense(int expenseId)
        {
            expenseRepository.Delete(e=>e.Id==expenseId);
        }

        public ExpenseDto GetExpenseById(int expenseId)
        {
            return expenseRepository.Get(e => e.Id == expenseId).ToExpenseDto();
        }

        public List<ExpenseDto> GetAllExpenses()
        {
            return expenseRepository.All().ToList().ToExpenseDtos();
        }
    }
}
