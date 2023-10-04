using YourProfessionWebApp.Domain.Entities;

namespace YourProfessionWebApp.Domain.Repositories.Interfaces {
    public interface IInterestRepository {
        IQueryable<Interest> GetAllInterests();
        Interest GetInterestById(int id);
        void SaveInterest(Interest entity);
        void DeleteInterest(int id);
    }
}
