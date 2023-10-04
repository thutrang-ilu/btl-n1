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
        public DbSet<BTLN1.Models.AccountViTri> AccountViTri { get; set; } = default!;
        public DbSet<BTLN1.Models.Ceo> Ceo { get; set; } = default!;
        public DbSet<BTLN1.Models.CeoViTri> CeoViTri { get; set; } = default!;
        public DbSet<BTLN1.Models.CongNhan> CongNhan { get; set; } = default!;
        public DbSet<BTLN1.Models.HopDong> HopDong { get; set; } = default!;
        public DbSet<BTLN1.Models.Luong> Luong { get; set; } = default!;
        public DbSet<BTLN1.Models.Sale> Sale { get; set; } = default!;
        public DbSet<BTLN1.Models.SaleViTri> SaleViTri { get; set; } = default!;
        public DbSet<BTLN1.Models.Staff> Staff { get; set; } = default!;
        public DbSet<BTLN1.Models.StaffViTri> StaffViTri { get; set; } = default!;
    }
}