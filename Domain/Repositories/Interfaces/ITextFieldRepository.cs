using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Domain.Repositories.Interfaces {
    public interface ITextFieldRepository {
        IQueryable<TextField> GetAllTextFields();
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
