using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Customer;

namespace BLL.Dtos.Expense
{
    internal static class ExpenseExtensions
    {
        public static ExpenseDto ToExpenseDto(this DAL.Entities.Expense expense)
        {
            return new ExpenseDto
            {
                Id = expense.Id,
                ProjectId = expense.ProjectId,
                Name = expense.Name,
                ExpenseDate = expense.ExpenseDate,
                Description = expense.Description,
                Amount = expense.Amount,
                Notes = expense.Notes
            };
        }

        public static DAL.Entities.Expense ToExpense(this ExpenseDto expenseDto)
        {
            return new DAL.Entities.Expense
            {
                Id = expenseDto.Id,
                ProjectId = expenseDto.ProjectId,
                Name = expenseDto.Name,
                ExpenseDate = expenseDto.ExpenseDate,
                Description = expenseDto.Description,
                Amount = expenseDto.Amount,
                Notes = expenseDto.Notes
            };
        }
        public static List<ExpenseDto> ToExpenseDtos(this List<DAL.Entities.Expense> expenses)
        {
            return expenses.Select(expense => new ExpenseDto
            {
                Id = expense.Id,
                ProjectId = expense.ProjectId,
                Name = expense.Name,
                ExpenseDate = expense.ExpenseDate,
                Description = expense.Description,
                Amount = expense.Amount,
                Notes = expense.Notes
            }).ToList();
        }

        public static List<DAL.Entities.Expense> ToExpenses(this List<ExpenseDto> expenseDtos)
        {
            return expenseDtos.Select(expenseDto => new DAL.Entities.Expense
            {
                Id = expenseDto.Id,
                ProjectId = expenseDto.ProjectId,
                Name = expenseDto.Name,
                ExpenseDate = expenseDto.ExpenseDate,
                Description = expenseDto.Description,
                Amount = expenseDto.Amount,
                Notes = expenseDto.Notes
            }).ToList();
        }
    }
}
