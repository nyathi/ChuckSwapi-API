using ChuckNorris_API.Models.chuck;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection.Metadata;
using System.Linq;

namespace ChuckNorris_API.Services.chuck
{
    
    public class CategoriesService : ICategoriesService
    {
        #region Properties
        private IAPIContantDefination _PIContantDefination { get; }
        #endregion
        #region Constructor
        public CategoriesService(IAPIContantDefination aPIContantDefination)
        {
            _PIContantDefination=aPIContantDefination;
        }
        #endregion

        #region Categories Service 
        public List<Categories>? GetCategories(string url)
        {
            List<Categories>? categories = new();
            try
            {
                categories.AddRange(JsonConvert.DeserializeObject<List<string>?>(_PIContantDefination.APIContantData(url)).Select(cat => new Categories { Name = cat }));

            }
            catch (Exception ex)
            {

            }

            return categories;
        }
        #endregion

        #region Private Actions
       
        #endregion
    } 
}
