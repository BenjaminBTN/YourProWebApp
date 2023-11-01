using System.Linq.Expressions;
using System.Text;
using YourProfessionWebApp.Domain.Repositories.Interfaces;
using YourProfessionWebApp.Domain.Repositories.TempImplementations;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Service {
    public static class SessionExtensions {
        private const string Key = "Result";

        public static void Set (this ISession session, ResultProViewModel model) {
            if (model == null) return;

            var stream = new MemoryStream ();
            using (var writer = new BinaryWriter(stream, Encoding.UTF8)) {

                writer.Write(model.RelevantProfessions.Count);

                foreach (var item in model.RelevantProfessions) {
                    writer.Write(item.Key.Id.ToString().ToUpper());
                    writer.Write(item.Value.ToString());
                }
                session.Set(Key, stream.ToArray());
            }

        }

        public static bool TryGetResult (this ISession session, out ResultProViewModel value) {
            IProfessionItemRepository repository = new TempProfessionItemRepository();

            if (session.TryGetValue(Key, out byte[] buffer)) {
                var stream = new MemoryStream(buffer);
                using(var reader = new BinaryReader(stream, Encoding.UTF8)) {
                    value = new ResultProViewModel();

                    var count = reader.ReadInt32();
                    for (int i = 0; i < count; i++) {
                        var itemId = reader.ReadString();
                        var lvl = reader.ReadInt32();

                        value.RelevantProfessions.Add(repository.GetProfessionItemById(new Guid(itemId)), lvl);
                    }
                    return true;
                }
            }
            value = null;
            return false;
        }


    }
}
