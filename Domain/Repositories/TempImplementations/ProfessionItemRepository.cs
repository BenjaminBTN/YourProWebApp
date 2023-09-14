using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using System.Linq;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class ProfessionItemRepository : IProfessionItemRepository {

        private List<ProfessionItem> _professionItems = new List<ProfessionItem> {
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Руководитель строительного проекта",
                Subtitle = "Менеджер проектов, в обязанности которого входит контроль и организация реализации строительного проекта",
                Text = "РП и всё тут"
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Асситент руководителя строительного проекта",
                Subtitle = "Помощник РП",
                Text = "АРП и всё тут"
            },
            new ProfessionItem() {
                Id = Guid.NewGuid(),
                Title = "Управляющий директор",
                Subtitle = "Директор по доверенности от УК",
                Text = "УД и всё тут"
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
                    if (_professionItems[i].Id == professionItem.Id) _professionItems[i].Id = professionItem.Id;
                }
            } else {
                _professionItems.Add(professionItem);
            }
        }
    }
}