using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Dtos.Customer;

namespace PalmBeachWebDesign.Models.Expense
{
    public class ManageExpenseVM
    {
        public int  Id { get; set; }
        [Required(ErrorMessage = "The Project is required.")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "The Customer is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The Date is required.")]
        public DateTime ExpenseDate { get; set; }
        [Required(ErrorMessage = "The Name is required.")]
        public string ExpenseName { get; set; }
        [StringLength(75)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Amount is required.")]
        public float Amount { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

    }
}