using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {
        private static readonly IInterestRepository _interestRepository;
        private static CloudOfInterests cloudOfInterests;

        static CloudController() {
            _interestRepository = new TempInterestRepository();
            cloudOfInterests = new CloudOfInterests(_interestRepository);
        }

        public IActionResult Index() {
            if (cloudOfInterests.counter >= 3) {
                cloudOfInterests.counter = 0;
                //для пробы:
                Response.Redirect("/Home/Index");
                return View("/Views/Home/Index.cshtml", new TempProfessionItemRepository().GetAllProfessionItems());
            }

            return View(cloudOfInterests.GetInterests());
        }



        [HttpPost]
        public string Index(Interest value) {
            return value.Title;
        }

        public string Push(string x) {
            return x;
        }

    }
}