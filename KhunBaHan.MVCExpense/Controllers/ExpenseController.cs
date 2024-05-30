using KhunBaHan.MVCExpense.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhunBaHan.MVCExpense.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext _context;

        public ExpenseController(ExpenseDbContext context)
        {
            _context = context;
        }

        public IActionResult Expense()
        {
            return View();
        }

        public IActionResult CreateOrEditExpense(int? Id)
        {
            if(Id != null)
            {
                var editExpenseLst = _context.Expenses.SingleOrDefault(expense => expense.Id == Id);
                return View(editExpenseLst);
            }
            return View();
        }

        public IActionResult OverView()
        {
            var allExpenseLst = _context.Expenses.ToList();
            var totalExpense = _context.Expenses.Sum(expense => expense.Value);
            ViewBag.Expenses = totalExpense;
            return View(allExpenseLst);
        }

        public IActionResult DeleteExpense(int? Id)
        {
            var deleteExpense = _context.Expenses.SingleOrDefault(expense => expense.Id == Id);
            _context.Expenses.Remove(deleteExpense);
            _context.SaveChanges();
            return RedirectToAction("OverView");
        }

        public IActionResult CreateOrEditExpenseForm(Expense expense)
        {
            if (expense.Id == 0)
            {
                _context.Expenses.Add(expense);
            } else
            {
                _context.Expenses.Update(expense);
            }
            _context.SaveChanges();

            return RedirectToAction("OverView");
        }
    }
}
