using Microsoft.AspNetCore.Mvc;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public string Index(string value) {
            return value;
        }

        public string Push(string x) {
            return x;
        }

    }
}