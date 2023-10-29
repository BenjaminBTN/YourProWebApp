using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class TempInterestRepository : IInterestRepository {

        private List<Interest> _interests = new List<Interest>() {
            new Interest() {
                Id = 0,
                Title = "Рыбалка"
            },
            new Interest() {
                Id = 1,
                Title = "Охота"
            },
            new Interest() {
                Id = 2,
                Title = "Автомобили"
            },
            new Interest() {
                Id = 3,
                Title = "Менеджмент"
            },
            new Interest() {
                Id = 4,
                Title = "Физика"
            },
            new Interest() {
                Id = 5,
                Title = "Спорт"
            },
            new Interest() {
                Id = 6,
                Title = "Строительство"
            },
            new Interest() {
                Id = 7,
                Title = "Программирование"
            },
            new Interest() {
                Id = 8,
                Title = "Футбол"
            },
            new Interest() {
                Id = 9,
                Title = "Рисование"
            }
        };


        public void Delete(int id) {
            _interests.Remove(_interests.Single(interest => interest.Id == id));
        }

        public IQueryable<int> GetAllId() {
            int[] ids = new int[_interests.Count];
            for (int i = 0; i < ids.Length; i++) {
                ids[i] = _interests[i].Id;
            }
            return ids.AsQueryable();
        }

        public Interest GetInterestById(int id) {
            return _interests.Single(interest => interest.Id == id);
        }

        public void Save(Interest interest) {
            if (_interests.Where(i => i.Id == interest.Id).Count() > 0) {
                _interests[_interests.FindIndex(i => i.Id == interest.Id)] = interest;
            } else {
                _interests.Add(interest);
            }
        }
    }
}
