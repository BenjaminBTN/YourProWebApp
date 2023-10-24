using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Models {
    public class ResultProViewModel {

        public Dictionary<string, int> RelevantProfessions { get; set; } = new Dictionary<string, int>();

        public int MaxOverlap {
            get {
                int max = 0;
                foreach (var profession in RelevantProfessions) {
                    if (profession.Value > max) max = profession.Value;
                }
                return max;
            }
        }

        public void GetBestProfession(IProfessionItemRepository proRepository, List<Interest> interests) {
            int max = 0;

            List<ProfessionItem> proItems = proRepository.GetAllProfessionItems().ToList();

            foreach (var proItem in proItems) {
                foreach (var interest in proItem.Interests) {
                    foreach (var i in interests) {
                        if (i.Id == interest.Id) {
                            max++;
                        }
                    }
                }
                if (max > 0) {
                    RelevantProfessions.Add(proItem.Title, max);
                }
                max = 0;
            }
        }
    }
}
