using System.Text;
using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Service {
    public static class SessionExtensions {
        private const string Key = "Result";

        public static void Set (this ISession session, ResultProViewModel model) {
            if (model == null) return;

            var stream = new MemoryStream ();
            using (var writer = new BinaryWriter(stream, Encoding.UTF8)) {
                foreach (var item in model.RelevantProfessions) {
                    writer.Write (item.Key);
                    writer.Write (item.Value);
                }
                session.Set(Key, stream.ToArray());
            }

        }

    }
}
