
using EmployeeApi.Models;

namespace EmployeeApi.Interfaces
{
    public interface IExternalVendorRepository
    {
        Task<List<Post>> GetPost();
        Task<Joke> GetJoke();
    }
}