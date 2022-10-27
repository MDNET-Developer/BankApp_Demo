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
        //private readonly BankContext _bankContext;
        //private readonly IAppUserRepository _appUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountMapper _accountMapper;
        //private readonly IAccountRepository _accountRepository;
        //public AccountController(BankContext bankContext, IAppUserRepository appUserRepository, IUserMapper userMapper, IAccountMapper accountMapper, IAccountRepository accountRepository)
        //{
        //    _bankContext = bankContext;
        //    _appUserRepository = appUserRepository;
        //    _userMapper = userMapper;
        //    _accountMapper = accountMapper;
        //    _accountRepository = accountRepository;
        //}
        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;

        public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
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
            //var userinfo = _userMapper.MapToUserList(_appUserRepository.GetId(id));
            var userinfo = _userRepository.GetbyId(id);
            return View(new UserListViewModel
            {
                MId=userinfo.Id,
                MName=userinfo.Name,
                MSurname=userinfo.Surname
            });
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
            //_accountRepository.Create(_accountMapper.Map(accountCreateModel));
            _accountRepository.Create(new Account
            {
                AccountNumber = accountCreateModel.MAccountNumber,
                Balance=accountCreateModel.MBalance,
                ApplicationUserId=accountCreateModel.MApplicationUserId
            });
            return RedirectToAction("Index","Bank");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userid)
        {
            var query = _accountRepository.GetQueryable();
            var account = query.Where(x => x.ApplicationUserId == userid);
            return View(account);
        }
    }
}