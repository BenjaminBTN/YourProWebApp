using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;

namespace YourProfessionWebApp.Models {
    public class CloudOfInterests {
        private List<Interest> threeInterests;
        internal int counter = 0;
        private readonly IInterestRepository interestRepository;

        public CloudOfInterests(IInterestRepository interestRepository) {
            this.interestRepository = interestRepository;
        }

        public List<Interest> GetInterests() {
            
            threeInterests = new List<Interest>();
            int countOfInterests = interestRepository.GetAllInterests().Count();

            int[] ints = new int[countOfInterests];
            for (int i = 0; i < countOfInterests; i++) {
                ints[i] = i;
            }

            //shuffle ints[]
            Random random = new Random();
            for (int i = countOfInterests - 1; i >= 1; i--) {
                int j = random.Next(i + 1);
                var temp = ints[j];
                ints[j] = ints[i];
                ints[i] = temp;
            }

            for (int i = 0; i < 3; i++) {
                threeInterests.Add(interestRepository.GetInterestById(ints[i]));
            }

            //threeInterests.AddRange(interestRepository.GetAllInterests().Take(3));

            counter++;

            return threeInterests;
        }
    }
}
