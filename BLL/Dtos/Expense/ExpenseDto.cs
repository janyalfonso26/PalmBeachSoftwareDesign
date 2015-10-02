using System;

namespace BLL.Dtos.Expense
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public float Amount { get; set; }
      
        public string Notes { get; set; }
    }
}
