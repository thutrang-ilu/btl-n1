using Microsoft.EntityFrameworkCore;
using BTLN1.Models;

namespace BTLN1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<BTLN1.Models.Account> Account { get; set; } = default!;
    }
}