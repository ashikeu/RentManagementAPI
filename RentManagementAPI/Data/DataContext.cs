using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models;

namespace RentManagementAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=103.197.204.163,3341;Database=rentmgt;user=hrpayrolluser;password=hrpayrolluser;Trusted_Connection=false;TrustServerCertificate=true");
        }


        public DbSet<PropertyInfo> PropertyInfo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Floor> Floor { get; set; } 
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Deposite> Deposite { get; set; }
        public DbSet<IncomeExpense> IncomeExpense { get; set; }
        public DbSet<IncomeExpenseTransaction> IncomeExpenseTransaction { get; set; }
        public DbSet<Report> Report { get; set; }
    }
}
