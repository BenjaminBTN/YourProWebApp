using YourProWebApp.Domain.Entities;
using YourProWebApp.Domain.Repositories.Interfaces;
using System.Linq;

namespace YourProWebApp.Domain.Repositories.TempImplementations {
    public class TempProfessionItemRepository : IProfessionItemRepository {

        private static IInterestRepository _interestRepository = new TempInterestRepository();

/*        public TempProfessionItemRepository(IInterestRepository interestRepository) {
            _interestRepository = interestRepository;
        }*/

        private static List<ProfessionItem> _professionItems = new List<ProfessionItem> {
            new ProfessionItem() {
                Id = 0,
                Title = "Руководитель строительного проекта",
                Text = "Менеджер проектов, в обязанности которого входит контроль и организация реализации строительного проекта",
                InterestsId = new List<int> { 3, 4, 6 }
            },
            new ProfessionItem() {
                Id = 1,
                Title = "Асситент руководителя строительного проекта",
                Text = "Помощник РП",
                InterestsId = new List<int> { 3, 4, 6 }
            },
            new ProfessionItem() {
                Id = 2,
                Title = "Художник",
                InterestsId = new List<int> { 9 }
            },
            new ProfessionItem() {
                Id = 3,
                Title = "Автомеханик", 
                InterestsId = new List < int > { 2 }
            },
            new ProfessionItem() {
                Id = 4,
                Title = "Футболист",
                InterestsId = new List < int > { 5, 8 }
            },
            new ProfessionItem() {
                Id = 5,
                Title = "Управляющий директор",
                Text = "Директор по доверенности от УК",
                InterestsId = new List < int > { 3 }
            }
        };

        public void DeleteProfessionItem(int id) {
            _professionItems.Remove(_professionItems.Single(p => p.Id == id));
        }

        public IQueryable<ProfessionItem> GetAllProfessionItems() {
            return _professionItems.AsQueryable();
        }

        public ProfessionItem GetProfessionItemById(int id) {
            return _professionItems.FirstOrDefault(p => p.Id == id);
        }

        public void SaveProfessionItem(ProfessionItem professionItem) {
            if (_professionItems.Where(p => p.Id == professionItem.Id).Count() > 0) {
                _professionItems[_professionItems.FindIndex(i => i.Id == professionItem.Id)] = professionItem;
            } else {
                _professionItems.Add(professionItem);
            }
        }
    }
}