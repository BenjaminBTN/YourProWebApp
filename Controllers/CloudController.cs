using Microsoft.AspNetCore.Mvc;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {

        public IActionResult Index() {
            return View();
        }

    }
}