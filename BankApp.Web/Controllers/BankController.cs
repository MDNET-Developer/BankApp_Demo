using BankApp.Web.Data.Context;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApp.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var accounts = _context.ApplicationUsers.Select(x=> new UserListViewModel
            {
                MId=x.Id,
                MName=x.Name,
                MSurname=x.Surname
            }).ToList();
            return View(accounts); 
        }
    }
}
