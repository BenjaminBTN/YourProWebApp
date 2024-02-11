using YourProWebApp.Domain.Entities;
using YourProWebApp.Domain.Repositories.Interfaces;

namespace YourProWebApp.Service {
    public static class InterestsService {

        public static List<Interest> GetThreeInterests(List<int> remainingInterests, IInterestRepository repository) {

            List<Interest> threeInterests = new List<Interest>();
            int countOfInterests = remainingInterests.Count();

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
                threeInterests.Add(repository.GetInterestById(remainingInterests.ElementAt(ints[i])));
            }

            return threeInterests;
        }
    }
}
