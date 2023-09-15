using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {

        public IActionResult Index() {
            return View();
        }

    }
}