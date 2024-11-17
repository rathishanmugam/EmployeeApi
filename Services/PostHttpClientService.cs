using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class PostHttpClientService(HttpClient httpClient) : IPostHttpClientService
    {
        public async Task<List<Post>> GetData()
        {
            return await httpClient.GetFromJsonAsync<List<Post>>("posts");
        }
    }
}