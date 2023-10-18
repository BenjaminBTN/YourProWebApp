using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {
        private readonly IInterestRepository interestRepository;
        private static CloudOfInterests cloudOfInterests;

        public CloudController(IInterestRepository interestRepository) {
            this.interestRepository = interestRepository;
        }

        [HttpGet]
        public IActionResult Index(int flag) {
            if (cloudOfInterests == null) {
                cloudOfInterests = new CloudOfInterests();
                cloudOfInterests.RemainingInterests = interestRepository.GetAllInterests().ToList();
            }

            if ((cloudOfInterests.FavoriteInterests.Count > 0 && cloudOfInterests.FavoriteInterests.Count % 3 == 0 && flag == 0) || cloudOfInterests.RemainingInterests.Count < 3) {
                return RedirectToAction("Result", "Cloud");
            }

            return View(cloudOfInterests.GetInterests());
        }

        [HttpGet]
        public IActionResult Result() {
            return View(cloudOfInterests);
        }

        [HttpPost]
        public void Add(int id) {
            cloudOfInterests.AddToFavoriteWithDel(interestRepository.GetInterestById(id));
            Response.Redirect("/Cloud/Index");
        }

        [HttpPost]
        public void Skip(List<Interest> list) {
            foreach (Interest interest in list) {
                cloudOfInterests.RemainingInterests.Remove(interest);
            }
            Response.Redirect("/Cloud/Index");
        }

    }
}