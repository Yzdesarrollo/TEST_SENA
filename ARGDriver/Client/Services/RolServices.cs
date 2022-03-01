 using ARGDriver.Client.Interfaces;
using ARGDriver.Shared.Models.Settings;
using System.Net.Http.Json;
using System.Text.Json;

namespace ARGDriver.Client.Services
{
    public class RolServices : IRolServices
    {
        private readonly HttpClient _httpClient;

        public RolServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // cambios
        const string BASE_URL = "/api/Rol";

        public async Task<List<Rol>> GetAllRoles()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Rol>>($"{BASE_URL}");
            return response;
        }

        public async Task<Rol> GetRolById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Rol>($"{BASE_URL}/{id}");
        }

        public async Task<Rol> CreateRol(Rol rol)
        {
            var response =  await _httpClient.PostAsJsonAsync($"{BASE_URL}", rol); 
            if(response.IsSuccessStatusCode)
            {
                var createdRol = await response.Content.ReadFromJsonAsync<Rol>();
                return createdRol;
            }
           return null;
        }     

        public async Task<Rol> UpdateRol(int id, Rol rol)
        {
            var request = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{id}", rol);
            var response = request;
            if (response.IsSuccessStatusCode)
            {
                var updateRol = await response.Content.ReadFromJsonAsync<Rol>();
                return updateRol;
            }
            return null;
         }

        public async Task<bool> DeleteRol(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
