using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Domain.Repositories.Interfaces {
    public interface IProfessionItemRepository {
        IQueryable<ProfessionItem> GetAllProfessionItems();
        ProfessionItem GetProfessionItemById(int id);
        void SaveProfessionItem(ProfessionItem entity);
        void DeleteProfessionItem(int id);
    }
}
