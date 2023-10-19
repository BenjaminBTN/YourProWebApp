using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {
        private readonly IInterestRepository interestRepository;
        private static CloudViewModel cloud;

        public CloudController(IInterestRepository interestRepository) {
            this.interestRepository = interestRepository;
        }

        [HttpGet]
        public IActionResult Index(int flag) {
            if (cloud == null) {
                cloud = new CloudViewModel();
                cloud.RemainingInterests = interestRepository.GetAllInterests().ToList();
            }

            if ((cloud.FavoriteInterests.Count > 0 && cloud.FavoriteInterests.Count % 3 == 0 && flag == 0) 
                || cloud.RemainingInterests.Count < 3) {
                return RedirectToAction("Result", "Cloud");
            }

            return View(cloud.GetInterests());
        }

        [HttpGet]
        public IActionResult Result() {
            return View(cloud);
        }

        [HttpPost]
        public void Add(int id) {
            cloud.AddToFavoriteWithDel(interestRepository.GetInterestById(id));
            Response.Redirect("/Cloud/Index");
        }

        [HttpPost]
        public void Skip(int id1, int id2, int id3) {
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i.Id == id1));
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i.Id == id2));
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i.Id == id3));
            Response.Redirect("/Cloud/Index");
        }

    }
}