using BankApp.Web.Data.Context;
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
            var accounts = _context.ApplicationUsers.ToList();
            return View(accounts); 
        }
    }
}
