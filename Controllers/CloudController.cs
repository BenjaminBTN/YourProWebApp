using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;
using YourProfessionWebApp.Service;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {
        private readonly IInterestRepository interestRepository;
        private readonly IProfessionItemRepository professionItemRepository;
        private static CloudViewModel cloud;
        private static ResultProViewModel result;

        public CloudController(IInterestRepository interestRepository, IProfessionItemRepository professionItemRepository) {
            this.interestRepository = interestRepository;
            this.professionItemRepository = professionItemRepository;
        }

        [HttpGet]
        public IActionResult Index(int flag) {
            if (cloud == null) {
                cloud = new CloudViewModel();
                cloud.RemainingInterests = interestRepository.GetAllId().ToList();
            }

            if ((cloud.FavoriteInterests.Count > 0 && cloud.FavoriteInterests.Count % 3 == 0 && flag == 0) 
                || cloud.RemainingInterests.Count < 3) {
                return RedirectToAction("Result", "Cloud");
            }

            cloud.ThreeInterests = InterestsService.GetThreeInterests(cloud.RemainingInterests, interestRepository);

            return View(cloud);
        }

        [HttpGet]
        public IActionResult Result() {
            result = new ResultProViewModel();
            result.GetBestProfession(professionItemRepository, cloud.FavoriteInterests);
            ViewBag.Remains = cloud.RemainingInterests.Count;

            return View(result);
        }

        [HttpGet]
        public void Refresh() {
            cloud = null;
            Response.Redirect("/Cloud/Index");
        }

        [HttpPost]
        public void Add(int id) {
            cloud.AddToFavoriteWithDel(id);
            Response.Redirect("/Cloud/Index");
        }

        [HttpPost]
        public void Skip(int id1, int id2, int id3) {
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i == id1));
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i == id2));
            cloud.RemainingInterests.Remove(cloud.RemainingInterests.Single(i => i == id3));
            Response.Redirect("/Cloud/Index?flag=1");
        }

    }
}