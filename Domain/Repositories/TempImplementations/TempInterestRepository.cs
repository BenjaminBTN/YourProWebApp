using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class TempInterestRepository : IInterestRepository {

        private List<Interest> _interests = new List<Interest> {
            new Interest() {
                Id = Guid.NewGuid(),
                Title = "Рыбалка",
            },
            new Interest() {
                Id = Guid.NewGuid(),
                Title = "Авто",
            },
            new Interest() {
                Id = Guid.NewGuid(),
                Title = "Охота",
            }
        };

        public void DeleteInterest(Guid id) {
            _interests.Remove(_interests.Single(interest => interest.Id == id));
        }

        public IQueryable<Interest> GetAllInterests() {
            return _interests.AsQueryable();
        }

        public Interest GetInterestById(Guid id) {
            return _interests.Single(interest => interest.Id == id);
        }

        public IEnumerable<Interest> Get_interests() {
            return _interests;
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
