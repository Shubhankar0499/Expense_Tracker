using ExpenseTracker.Application.DTOs;
using System.Net.Http.Json;


namespace ExpenseTracker.Application.Clients;


public class UserClient
{

    private readonly HttpClient _httpClient;


    public UserClient(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }



    public async Task<UserDto?> GetUserById(int id)
    {

        var response =
            await _httpClient.GetAsync(
                $"api/User/{id}"
            );


        if (!response.IsSuccessStatusCode)
        {
            return null;
        }


        return await response.Content
            .ReadFromJsonAsync<UserDto>();

    }

}