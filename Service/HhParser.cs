using Newtonsoft.Json.Linq;
using YourProWebApp.Domain.Entities;
using YourProWebApp.Domain.Repositories.Interfaces;

namespace YourProWebApp.Service {
    public static class HhParser {
        static HttpClient httpClient = new HttpClient();
        
        public static async Task ReloadDbFromHh(IProfessionItemRepository repository) {
            var request = await httpClient.GetAsync("https://api.hh.ru/professional_roles");
            var response = await request.Content.ReadAsStringAsync();
            var json = JObject.Parse(response);

            var categories = json["categories"];

            foreach (var cat in categories) {
                var roles = cat["roles"];
                foreach (var item in roles) {
                    if (item != null && !repository.GetAllProfessionItems().Select(x => x.Title).Equals(item["name"].ToString())) {
                        repository.SaveProfessionItem(new ProfessionItem() { 
                            Id = repository.GetAllProfessionItems().Count(), 
                            Title = item["name"].ToString(), 
                            Text  = string.Empty, 
                            Category = cat.ToString(), 
                            InterestsId = new List<int>(), 
                        });
                    }
                }
            }
        }

    }
}
