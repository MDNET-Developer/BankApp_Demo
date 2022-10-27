using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel account)
        {
            return new Account
            {
               AccountNumber=account.MAccountNumber,
               ApplicationUserId=account.MApplicationUserId,
               Balance=account.MBalance,
            };
        }
    }
}
