using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public interface IPostHttpClientService
    {
         Task<List<Post>> GetData();
    }
}