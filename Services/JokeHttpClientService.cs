using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class JokeHttpClientService(HttpClient httpClient) : IJokeHttpClientService
    {
        public async Task<Joke> GetData()
        {
            return await httpClient.GetFromJsonAsync<Joke>("random_joke");
        }
    }
}