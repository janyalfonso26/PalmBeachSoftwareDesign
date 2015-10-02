using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Expense
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
