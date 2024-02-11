using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Models {
    public class CloudViewModel {
        
        public List<Interest> ThreeInterests { get; set; }
        public List<int> FavoriteInterests { get; set; } = new List<int>();
        public List<int> RemainingInterests { get; set; }

        public void AddToFavoriteWithDel(int interestId) {
            if (FavoriteInterests.Contains(interestId) || !RemainingInterests.Contains(interestId)) {
                return;
            }
            FavoriteInterests.Add(interestId);
            RemainingInterests.Remove(interestId);
        }
    }
}
