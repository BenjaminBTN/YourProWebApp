using YourProfessionWebApp.Domain.Entities;

namespace YourProfessionWebApp.Domain.Repositories.TempImplementations {
    public class TextFieldRepository {

        private List<TextField> _textFields = new List<TextField>() {
            new TextField() {
                Id = Guid.NewGuid(),
                Title = "Главная",
                CodeWord = "PageIndex"
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
            _textFields.Remove(_textFields.Single(p => p.Id == id));
        }

        public IQueryable<TextField> GetAllTextFields() {
            return _textFields.AsQueryable();
        }

        public TextField GetTextFieldById(Guid id) {
            return _textFields.FirstOrDefault(p => p.Id == id);
        }

        public void SaveTextField(TextField textField) {
            if (_textFields.Where(p => p.Id == textField.Id).Count() > 0) {
                for (int i = 0; i < _textFields.Count(); i++) {
                    if (_textFields[i].Id == textField.Id) _textFields[i].Id = textField.Id;
                }
            }
            else {
                _textFields.Add(textField);
            }
        }
    }
}
