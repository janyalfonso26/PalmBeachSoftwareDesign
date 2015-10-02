using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Customer;
using BLL.Dtos.Expense;

namespace BLL.Services
{
    public interface IExpenseService
    {
        void AddExpense(ExpenseDto expense);
        void UpdateExpense(ExpenseDto expense);
        void RemoveExpense(int expenseId);
        ExpenseDto GetExpenseById(int expenseId);
        List<ExpenseDto> GetAllExpenses();
    }
}
