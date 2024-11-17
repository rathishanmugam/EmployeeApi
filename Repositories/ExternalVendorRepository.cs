using EmployeeApi.Interfaces;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Repositories
{
    public class ExternalVendorRepository(
        IPostHttpClientService postHttpClientService,
        IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorRepository
    {
        public async Task<List<Post>> GetPost()
        {
            return await postHttpClientService.GetData();
        }

        public async Task<Joke> GetJoke()
        {
            return await jokeHttpClientService.GetData();
        }
    }
}