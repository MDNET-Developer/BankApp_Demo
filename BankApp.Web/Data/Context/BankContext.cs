using BankApp.Web.Data.Configuration;
using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Web.Data.Context
{
    public class BankContext:DbContext
    {
        public BankContext(DbContextOptions<BankContext> options):base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfigration());
            modelBuilder.ApplyConfiguration(new AccountConfigration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
