using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KiemTra2425.Models;

namespace KiemTra2425.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KiemTra2425.Models.NguyenVanNguyen> NguyenVanNguyen { get; set; } = default!;
    }
}
