using Microsoft.EntityFrameworkCore;
using ReimbursementApi.Models;
using System;

namespace ReimbursementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Receipt> Receipts { get; set; }
    }
}
