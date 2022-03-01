using ARGDriver.Client.Interfaces;
using ARGDriver.Shared.Models.Settings;
using System.Net.Http.Json;
using System.Text.Json;

namespace ARGDriver.Client.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // cambios
        const string BASE_URL = "/api/User";

        public async Task<List<User>> GetAllUsers()
        {
            var response = await _httpClient.GetFromJsonAsync<List<User>>($"{BASE_URL}");
            return response;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{BASE_URL}/{id}");
        }

        public async Task<User> CreateUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BASE_URL}", user);
            if (response.IsSuccessStatusCode)
            {
                var createdUser = await response.Content.ReadFromJsonAsync<User>();
                return createdUser;
            }
            return null;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{id}", user);
            if (response.IsSuccessStatusCode)
            {
                var updateUser = await response.Content.ReadFromJsonAsync<User>();
                return updateUser;
            }
            return null;
        }

        public async Task<User> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{id}");
            var deleteUser = await response.Content.ReadFromJsonAsync<User>();
            return deleteUser;
        }
    }
}
