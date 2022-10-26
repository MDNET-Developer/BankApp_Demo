using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Repository;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _bankContext;
   
        public AccountController(BankContext bankContext)
        {
            _bankContext = bankContext;
           
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var userinfo = _bankContext.ApplicationUsers.Select(x => new UserListViewModel
            {
                MId = x.Id,
                MName = x.Name,
                MSurname = x.Surname
            }).SingleOrDefault(x => x.MId == id);
            return View(userinfo);
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
           
            _bankContext.Accounts.Add(new BankApp.Web.Data.Entities.Account
            {
                AccountNumber=accountCreateModel.MAccountNumber,
                Balance=accountCreateModel.MBalance,
                ApplicationUserId=accountCreateModel.MApplicationUserId

            });
            _bankContext.SaveChanges();
            return RedirectToAction("Index","Bank");
        }
    }
}