
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using WebApplication1.Models; // Replace with the namespace where your model classes are located

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("UserApiClient");
    }
   
    public async Task<List<User>> GetUsers()
    {
        var users= await _httpClient.GetFromJsonAsync<List<User>>("api/Users");

        return users;

    }

    public async Task<User> GetUserById(int id)
    {
        var response = await _httpClient.GetAsync($"api/users/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<User>();
        }
        else
        {
            // Handle errors appropriately (e.g., log, throw exception, etc.)
            throw new Exception($"Failed to fetch user. Status Code: {response.StatusCode}");
        }
    }



}
