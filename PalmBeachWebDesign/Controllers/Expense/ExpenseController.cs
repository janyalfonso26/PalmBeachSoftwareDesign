using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Dtos.Expense;
using BLL.Services;
using PalmBeachWebDesign.Models.Expense;
using System.Web.Script.Serialization;

namespace PalmBeachWebDesign.Controllers.Expense
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService expenseService;
        private readonly ICustomerService customerService;
        private readonly IProjectService projectService;
        public ExpenseController(IExpenseService _expenseService, ICustomerService _customerService, IProjectService _projectService) : base()
        {
            expenseService = _expenseService;
            customerService = _customerService;
            projectService = _projectService;
        }
        // GET: Expense
        public ActionResult Index()
        {
            var vm = from e in expenseService.GetAllExpenses()
                         join p in projectService.GetAllProjects() on e.ProjectId equals p.Id
                         join c in customerService.GetAllCustomers() on p.CustomerId equals c.Id
                         select new ExpenseReportVM
                         {
                             ExpenseId = e.Id,
                             Date = e.ExpenseDate,
                             CustomerName = c.Name,
                             ProjectName = p.Name,
                             Description = e.Description,
                             Amount = e.Amount
                         };
            return View(vm);
        }
        
        // GET: Expense/Manage
        public ActionResult Manage(int id=0)
        {
            var manageVM = new ManageExpenseVM
            {
                Customers = customerService.GetAllCustomers().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }),
                Projects = new List<SelectListItem>()
            };


            if (id > 0)
            {
                var expense = expenseService.GetExpenseById(id);
                manageVM.Id = expense.Id;
                manageVM.Amount = expense.Amount;
                manageVM.ProjectId = expense.ProjectId;
                manageVM.Description = expense.Description;
                manageVM.Notes = expense.Notes;
                manageVM.ExpenseDate = expense.ExpenseDate;
                manageVM.ExpenseName = expense.Name;

                manageVM.CustomerId = projectService.GetAllProjects()
                        .Where(p => p.Id == expense.ProjectId)
                        .Select(p => p.CustomerId)
                        .FirstOrDefault();
                manageVM.Projects = projectService.GetAllProjects().Where(p=>p.CustomerId == manageVM.CustomerId).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });
                return View("Edit", manageVM);
            }
            return View("Create",manageVM);
        }

        // POST: Expense/Manage
        [HttpPost]
        public ActionResult Manage(ManageExpenseVM modelVm)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var modelDto = new ExpenseDto
                        {
                            Id = modelVm.Id,
                            ProjectId = modelVm.ProjectId,
                            Description = modelVm.Description,
                            Amount = modelVm.Amount,
                            ExpenseDate = modelVm.ExpenseDate,
                            Name = modelVm.ExpenseName,
                            Notes = modelVm.Notes
                        };

                        if (modelVm.Id > 0)
                        {
                            expenseService.UpdateExpense(modelDto);
                        }
                        else
                        {
                            expenseService.AddExpense(modelDto);

                        }
                    }
                    
                }
                catch (Exception)
                {
                    ///TODO:Add exception handler 
                    throw;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        

        //
        public JsonResult LoadProjects(int id)
        {
            try
            {
                var Projects = projectService.GetAllProjects().Where(p => p.CustomerId == id).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });

                var jsonProjects = Json(Projects.ToList(), JsonRequestBehavior.AllowGet);
                return jsonProjects;
            }
            catch
            {
                return null;
            }
        }

        // POST: Expense/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    expenseService.RemoveExpense(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
