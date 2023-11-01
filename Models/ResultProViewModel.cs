using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Service;

namespace YourProfessionWebApp.Models {
    public class ResultProViewModel {

        public Dictionary<ProfessionItem, int> RelevantProfessions { get; set; }

        public int MaxOverlap {
            get {
                int max = 0;
                foreach (var profession in RelevantProfessions) {
                    if (profession.Value > max) max = profession.Value;
                }
                return max;
            }
        }

        public ResultProViewModel() { }

        public ResultProViewModel(IProfessionItemRepository repository, List<int> interests) {
            RelevantProfessions = ProfessionsService.GetRelevantProfessions(repository, interests);
        }
    }
}
