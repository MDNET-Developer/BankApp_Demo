using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApp.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _context;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserMapper _userMapper;
        public BankController(BankContext context, IAppUserRepository appUserRepository, IUserMapper userMapper)
        {
            _context = context;
            _appUserRepository = appUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            //var accounts = _context.ApplicationUsers.Select(x=> new UserListViewModel
            //{
            //    MId=x.Id,
            //    MName=x.Name,
            //    MSurname=x.Surname
            //}).ToList();
            var accounts =_userMapper.MapToListOfUserList(_appUserRepository.Getall());
            return View(accounts); 
        }
    }
}
