using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.Repository
{
    public class AppUserRepository
    {
        private readonly BankContext _bankContext;

        public AppUserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public List<ApplicationUser> Getall()
        {
            return _bankContext.ApplicationUsers.ToList();
        }

        public ApplicationUser GetId(int id)
        {
            return _bankContext.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }
    }
}
