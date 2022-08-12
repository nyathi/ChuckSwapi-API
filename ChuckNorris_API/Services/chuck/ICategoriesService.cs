using ChuckNorris_API.Models.chuck;

namespace ChuckNorris_API.Services.chuck
{
    public interface ICategoriesService
    {
        List<Categories>? GetCategories();
    }
}