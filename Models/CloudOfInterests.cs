using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;

namespace YourProfessionWebApp.Models {
    public class CloudOfInterests {

        public List<Interest> FavoriteInterests { get; set; } = new List<Interest>();

        public List<Interest> RemainingInterests { get; set; }

        public List<Interest> GetInterests() {

            List<Interest> threeInterests = new List<Interest>();
            int countOfInterests = RemainingInterests.Count();

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
                threeInterests.Add(RemainingInterests.ElementAt(ints[i]));
            }

/*            for (int i = 0; i < 3; i++) {
                allInterests.RemoveAt(ints[i]);
            }*/

            return threeInterests;
        }

        public void AddToFavoriteWithDel(Interest interest) {
            if(FavoriteInterests.Contains(interest) || !RemainingInterests.Contains(interest)) {
                return;
            }
            FavoriteInterests.Add(interest);
            RemainingInterests.Remove(interest);
        }
    }
}
