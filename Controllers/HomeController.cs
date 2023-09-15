using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        IProfessionItemRepository _professionItemRepository;

        public HomeController(IProfessionItemRepository itemRepository, ILogger<HomeController> logger) {
            _professionItemRepository = itemRepository;
            _logger = logger;
        }

        public IActionResult Index() {
            return View(_professionItemRepository.GetAllProfessionItems());
        }

        public IActionResult Cloud() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}