using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResRestaurantManagment.Data;
using ResRestaurantManagment.Models;
using System.Diagnostics;
using System.Linq;

namespace ResRestaurantManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context,UserManager<AppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            int usersCount = _userManager.Users.Count();
            int resListsCount = _context.ResList.Count();
            int resTablesCount = _context.ResTable.Count();
            ViewData["UsersCount"] = usersCount;
            ViewData["ReservationCount"] = resListsCount;
            ViewData["ReservationTableCount"] = resTablesCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}