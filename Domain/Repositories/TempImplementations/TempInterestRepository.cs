using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class TempInterestRepository : IInterestRepository {

        private List<Interest> _interests = new List<Interest>() {
            new Interest() {
                Id = 1,
                Title = "Рыбалка"
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
            },
            new Interest() {
                Id = 10,
                Title = "Охота"
            }
        };


        public void DeleteInterest(int id) {
            _interests.Remove(_interests.Single(interest => interest.Id == id));
        }

        public IQueryable<Interest> GetAllInterests() {
            return _interests.AsQueryable();
        }

        public Interest GetInterestById(int id) {
            return _interests.Single(interest => interest.Id == id);
        }

        public void SaveInterest(Interest interest) {
            if (_interests.Where(i => i.Id == interest.Id).Count() > 0) {
                _interests[_interests.FindIndex(i => i.Id == interest.Id)] = interest;
            } else {
                _interests.Add(interest);
            }
        }
    }
}
