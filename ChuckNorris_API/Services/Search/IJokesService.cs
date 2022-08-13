using ChuckNorris_API.Models.Search;
using ChuckNorris_API.Models.Swapi;

namespace ChuckNorris_API.Services.Search
{
    public interface IJokesService
    {
        Jokes? GetJoke(string url);
        People? GetProfile(string url);
    }
}