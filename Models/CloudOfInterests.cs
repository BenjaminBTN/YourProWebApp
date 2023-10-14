using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;

namespace YourProfessionWebApp.Models {
    public class CloudOfInterests {
        public List<Interest> allInterests = new TempInterestRepository().GetAllInterests().ToList();
        internal int counter = 0;

        public List<Interest> GetInterests() {

            List<Interest> threeInterests = new List<Interest>();
            int countOfInterests = allInterests.Count();

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
                threeInterests.Add(allInterests.ElementAt(ints[i]));
            }

/*            for (int i = 0; i < 3; i++) {
                allInterests.RemoveAt(ints[i]);
            }*/

            counter++;

            return threeInterests;
        }
    }
}
