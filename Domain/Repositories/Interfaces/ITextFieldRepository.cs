using YourProfessionWebApp.Domain.Entities;

namespace YourProfessionWebApp.Domain.Repositories.Interfaces {
    public interface ITextFieldRepository {
        IQueryable<TextField> GetAllPages();
        TextField GetPageByCodeWord(string codeWotrd);
        void SavePage(TextField entity);
        void DeletePage(Guid id);
    }
}
