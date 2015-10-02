using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Expense
{
    public class ExpenseReport
    {
        public int ExpenseId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }
}
