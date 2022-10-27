using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repository;
using BankApp.Web.Mapping;
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
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountMapper _accountMapper;
        private readonly IAccountRepository _accountRepository;
        public AccountController(BankContext bankContext, IAppUserRepository appUserRepository, IUserMapper userMapper, IAccountMapper accountMapper, IAccountRepository accountRepository)
        {
            _bankContext = bankContext;
            _appUserRepository = appUserRepository;
            _userMapper = userMapper;
            _accountMapper = accountMapper;
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            //var userinfo = _bankContext.ApplicationUsers.Select(x => new UserListViewModel
            //{
            //    MId = x.Id,
            //    MName = x.Name,
            //    MSurname = x.Surname
            //}).SingleOrDefault(x => x.MId == id);
            var userinfo = _userMapper.MapToUserList(_appUserRepository.GetId(id));
            return View(userinfo);
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {

            //_bankContext.Accounts.Add(new BankApp.Web.Data.Entities.Account
            //{
            //    AccountNumber=accountCreateModel.MAccountNumber,
            //    Balance=accountCreateModel.MBalance,
            //    ApplicationUserId=accountCreateModel.MApplicationUserId

            //});
            //_bankContext.SaveChanges();
            _accountRepository.Create(_accountMapper.Map(accountCreateModel));
            return RedirectToAction("Index","Bank");
        }
    }
}