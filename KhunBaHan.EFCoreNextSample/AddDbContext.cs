using KhunBaHan.EFCoreNextSample.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreNextSample
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions options) : base(options) { }
        public DbSet<BlogModel> Blog { get; set; }
    }
}
