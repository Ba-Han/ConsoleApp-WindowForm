using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.MVCExpense.Models
{
    public class ExpenseDbContext : DbContext
    {
        public  DbSet<Expense> Expenses { get; set; }

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
            
        }
    }
}
