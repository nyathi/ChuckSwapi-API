using ChuckNorris_API.Models.chuck;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection.Metadata;
using System.Linq;

namespace ChuckNorris_API.Services.chuck
{
    
    public class CategoriesService : ICategoriesService
    {
        #region Constructor
        #endregion

        #region Categories Service 
        public List<Categories>? GetCategories()
        {
            List<Categories>? categories = new();
            try
            {
                categories.AddRange(JsonConvert.DeserializeObject<List<string>?>(APIContant).Select(cat => new Categories { Name = cat }));

            }
            catch (Exception ex)
            {

            }

            return categories;
        }
        #endregion

        #region Private Actions
        private string? APIContant
        {
            get
            {
                var client = new RestClient("https://api.chucknorris.io/jokes/categories");
                var request = new RestRequest();
                var response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    return null;
                }

                return response.Content;
            }
        }
        #endregion
    } 
}
