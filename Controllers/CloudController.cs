using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {
        private readonly IInterestRepository _interestRepository;
        private static CloudOfInterests cloudOfInterests = new CloudOfInterests();
        static List<Interest> resultListOfInterests = new List<Interest>();

        public CloudController() {
            _interestRepository = new TempInterestRepository();
        }

        public IActionResult Index() {
            if (cloudOfInterests.counter >= 3) {
                cloudOfInterests.counter = 0;
                //для пробы:
                Response.Redirect("/Cloud/Result");
                return View("/Views/Home/Index.cshtml", new TempProfessionItemRepository().GetAllProfessionItems());
            }

            return View(cloudOfInterests.GetInterests());
        }



        [HttpPost]
        public void Index(Interest value) {
            resultListOfInterests.Add(value);
            int index = _interestRepository.GetAllInterests().ToList().IndexOf(_interestRepository.GetAllInterests().First(x => x.Title == value.Title));
            cloudOfInterests.allInterests.RemoveAt(index);
            Response.Redirect("/Cloud/Index");
        }

        public IActionResult Result() {
            return View(resultListOfInterests);
        }

    }
}