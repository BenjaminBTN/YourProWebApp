using YourProWebApp.Domain.Entities;
using YourProWebApp.Domain.Repositories.Interfaces;
using YourProWebApp.Service;

namespace YourProWebApp.Models {
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
