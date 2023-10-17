using YourProfessionWebApp.Models;

namespace YourProfessionWebApp.Service {
    public static class SessionExtensions {
        private const string Key = "Cloud";

        public static void Set (this ISession session, CloudOfInterests cloud) {
            if (cloud == null) return;


        }

    }
}
