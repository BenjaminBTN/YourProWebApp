using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Domain.Repositories.Interfaces {
    public interface IInterestRepository {
        IQueryable<int> GetAllId();
        Interest GetInterestById(int id);
        void Save(Interest entity);
        void Delete(int id);
    }
}
