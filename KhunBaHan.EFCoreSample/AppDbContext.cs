using KhunBaHan.EFCoreSample.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreSample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CategoryModel> Category { get; set; }
    }
}