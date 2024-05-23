using KhunBaHan.EFCoreSample.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreSample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tbl_Category> Tbl_Category { get; set; }
    }
}