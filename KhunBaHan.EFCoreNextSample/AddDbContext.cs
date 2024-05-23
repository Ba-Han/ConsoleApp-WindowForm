using KhunBaHan.EFCoreNextSample.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreNextSample
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Tbl_BlogModel> Tbl_BlogModels { get; set; }
    }
}
