using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Domain.Repositories.Interfaces {
    public interface IProfessionItemRepository {
        IQueryable<ProfessionItem> GetAllProfessionItems();
        ProfessionItem GetProfessionItemById(Guid id);
        void SaveProfessionItem(ProfessionItem entity);
        void DeleteProfessionItem(Guid id);
    }
}
