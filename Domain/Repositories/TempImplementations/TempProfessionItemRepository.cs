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
                Id = Guid.NewGuid(),
                Title = "Руководитель строительного проекта",
                Text = "Менеджер проектов, в обязанности которого входит контроль и организация реализации строительного проекта",
                InterestsId = new List<int> { 3, 4, 6 }
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Асситент руководителя строительного проекта",
                Text = "Помощник РП",
                InterestsId = new List<int> { 3, 4, 6 }
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Художник",
                InterestsId = new List<int> { 9 }
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Автомеханик", 
                InterestsId = new List < int > { 2 }
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Футболист",
                InterestsId = new List < int > { 5, 8 }
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Управляющий директор",
                Text = "Директор по доверенности от УК",
                InterestsId = new List < int > { 3 }
            }
        };

        public void DeleteProfessionItem(Guid id) {
            _professionItems.Remove(_professionItems.Single(p => p.Id == id));
        }

        public IQueryable<ProfessionItem> GetAllProfessionItems() {
            return _professionItems.AsQueryable();
        }

        public ProfessionItem GetProfessionItemById(Guid id) {
            return _professionItems.FirstOrDefault(p => p.Id == id);
        }

        public void SaveProfessionItem(ProfessionItem professionItem) {
            if (_professionItems.Where(p => p.Id == professionItem.Id).Count() > 0) { 
                for(int i = 0; i < _professionItems.Count(); i++) {
                    if (_professionItems[i].Id == professionItem.Id) _professionItems[i] = professionItem;
                }
            } else {
                _professionItems.Add(professionItem);
            }
        }
    }
}