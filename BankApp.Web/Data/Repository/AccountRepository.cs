using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;

namespace BankApp.Web.Data.Repository
{
    
    public class AccountRepository: IAccountRepository
    {
        private readonly BankContext _bankContext;

        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void  Create(Account account)
        {
            _bankContext.Accounts.Add(account);
            _bankContext.SaveChanges();

        }
    }
}
