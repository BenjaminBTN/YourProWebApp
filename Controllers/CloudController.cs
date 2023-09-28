using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Controllers {
    public class CloudController : Controller {

        private static IInterestRepository _interestRepository;

        public CloudController(IInterestRepository interestRepository) {
            _interestRepository = interestRepository;
        }

        public IActionResult Index() {
            Random random = new Random();

            List<Interest> threeInterests = new List<Interest>();
            for (int i = 0; i < 3; i++) {
                threeInterests.Add(_interestRepository.GetInterestById(random.Next(1, _interestRepository.GetAllInterests().Count() + 1)));
            }
            return View(threeInterests);
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