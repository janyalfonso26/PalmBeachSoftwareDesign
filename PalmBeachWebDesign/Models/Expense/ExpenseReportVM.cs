using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Dtos.Expense;

namespace PalmBeachWebDesign.Models.Expense
{
    public class ExpenseReportVM
    {
        public int ExpenseId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }
}