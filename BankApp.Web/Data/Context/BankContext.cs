using Microsoft.EntityFrameworkCore;

namespace BankApp.Web.Data.Context
{
    public class BankContext:DbContext
    {
        public BankContext(DbContextOptions<BankContext> options):base(options)
        {

        }
    }
}
