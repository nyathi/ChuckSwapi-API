using ChuckNorris_API.Models.chuck;
using ChuckNorris_API.Services.chuck;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChuckNorris_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        #region Properties
        ICategoriesService _categoriesService;
        #endregion

        #region Constructor
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        #endregion

        // GET: api/<CategoriesController>
        [HttpGet, Route("/chuck/categories")]
        public List<Categories>? Get()
        {
            return _categoriesService.GetCategories("https://api.chucknorris.io/jokes/categories");
        }
    }
}
