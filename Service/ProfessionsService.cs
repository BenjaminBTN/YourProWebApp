using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Service {
    public static class ProfessionsService {

        public static Dictionary<ProfessionItem, int> GetRelevantProfessions(IProfessionItemRepository repository, 
                                                                      List<int> interests) {
            
            int max = 0;

            Dictionary<ProfessionItem, int> relevantProfessions = new Dictionary<ProfessionItem, int>();
            List<ProfessionItem> proItems = repository.GetAllProfessionItems().ToList();

            foreach (var proItem in proItems) {
                foreach (var interest in proItem.InterestsId) {
                    foreach (var i in interests) {
                        if (i == interest) {
                            max++;
                        }
                    }
                }
                if (max > 0) {
                    relevantProfessions.Add(proItem, max);
                }
                max = 0;
            }

            return relevantProfessions;
        }
    }
}
