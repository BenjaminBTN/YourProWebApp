using Microsoft.AspNetCore.Mvc;
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
            if (cloudOfInterests.counter >= 2) {
                cloudOfInterests.counter = 0;
                //для пробы:
                return View("/Views/Home/Index.cshtml", new TempProfessionItemRepository().GetAllProfessionItems());
            }

            return View(cloudOfInterests.GetInterests());
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