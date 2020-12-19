using ASPNETCoreVueChecklist.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreVueChecklist
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChecklistItem> ChecklistItems { get; set; }
    }
}
