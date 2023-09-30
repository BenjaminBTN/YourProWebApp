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
            int countOfInterests = _interestRepository.GetCountOfInterests();

            List<Interest> threeInterests = new List<Interest>();

            int[] ints = new int[countOfInterests];
            for (int i = 0; i < countOfInterests; i++) {
                ints[i] = i;
            }

            //shuffle ints[]
            for (int i = countOfInterests - 1; i >= 1; i--) {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = ints[j];
                ints[j] = ints[i];
                ints[i] = temp;
            }

            for (int i = 0; i < 3; i++) {
                threeInterests.Add(_interestRepository.GetInterestById(ints[i]));
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