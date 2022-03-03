using ARGDriver.Client.Interfaces;
using ARGDriver.Shared.Models.Insurance;
using System.Net.Http.Json;

namespace ARGDriver.Client.Services
{
    public class InsurerServices : IInsurerServices
    {
        private readonly HttpClient _httpClient;

        public InsurerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // cambios
        const string BASE_URL = "/api/Insurer";

        public async Task<List<Insurer>> GetAllInsurers()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Insurer>>($"{BASE_URL}");
            return response;
        }

        public async Task<Insurer> GetInsurerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Insurer>($"{BASE_URL}/{id}");
        }

        public async Task<Insurer> CreateInsurer(Insurer insurer)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BASE_URL}", insurer);
            if (response.IsSuccessStatusCode)
            {
                var createdInsurer = await response.Content.ReadFromJsonAsync<Insurer>();
                return createdInsurer;
            }
            return null;
        }

        public async Task<Insurer> UpdateInsurer(int id, Insurer insurer)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{id}", insurer);
            if (response.IsSuccessStatusCode)
            {
                var updateInsurer = await response.Content.ReadFromJsonAsync<Insurer>();
                return updateInsurer;
            }
            return null;
        }

        public async Task<bool> DeleteInsurer(int id)
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

    
