using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class TempTextFieldRepository : ITextFieldRepository {

        private List<TextField> _textFields = new List<TextField>() {
            new TextField() {
                Id = Guid.NewGuid(),
                Title = "Главная",
                CodeWord = "PageIndex"
            },
            new TextField() {
                Id = Guid.NewGuid(),
                Title = "Облако интересов",
                CodeWord = "PageInterests"
            },
            new TextField() {
                Id = Guid.NewGuid(),
                Title = "Выбор профессии",
                CodeWord = "PagePro"
            },
            new TextField() {
                Id = Guid.NewGuid(),
                Title = "Контакты",
                CodeWord = "PageContacts"
            }
        };

        public void DeleteTextField(Guid id) {
            _textFields.Remove(_textFields.Single(t => t.Id == id));
        }

        public IQueryable<TextField> GetAllTextFields() {
            return _textFields.AsQueryable();
        }

        public TextField GetTextFieldByCodeWord(string codeWord) {
            return _textFields.FirstOrDefault(t => t.CodeWord == codeWord);
        }

        // реализация этого же метода в другом синтаксисе в классе TempInterestRepository
        public void SaveTextField(TextField textField) {
            if (_textFields.Where(t => t.Id == textField.Id).Count() > 0) {
                for (int i = 0; i < _textFields.Count(); i++) {
                    if (_textFields[i].Id == textField.Id) _textFields[i] = textField;
                }
            }
            else {
                _textFields.Add(textField);
            }
        }
    }
}
