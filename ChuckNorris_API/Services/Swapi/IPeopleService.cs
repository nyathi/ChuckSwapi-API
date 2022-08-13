using ChuckNorris_API.Models.Swapi;

namespace ChuckNorris_API.Services.Swapi
{
    public interface IPeopleService
    {
        People? List(string url);
    }
}