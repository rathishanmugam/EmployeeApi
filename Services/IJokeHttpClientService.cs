using EmployeeApi.Models;
namespace EmployeeApi.Services
{
    public interface IJokeHttpClientService
    {
        Task<Joke> GetData();
    }
}