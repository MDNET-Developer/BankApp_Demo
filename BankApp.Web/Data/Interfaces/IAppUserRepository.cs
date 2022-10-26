using BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace BankApp.Web.Data.Interfaces
{
    public interface IAppUserRepository
    {
        List<ApplicationUser> Getall();
        ApplicationUser GetId(int id);
    }
}
