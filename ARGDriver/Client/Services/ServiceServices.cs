 using ARGDriver.Client.Interfaces;
using ARGDriver.Shared.Models.Services;
using System.Net.Http.Json;
using System.Text.Json;

namespace ARGDriver.Client.Services
{
    public class ServiceServices : IServiceServices
    {
        private readonly HttpClient _httpClient;

        public ServiceServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // cambios
        const string BASE_URL = "/api/Service";

        public async Task<List<Service>> GetAllServices()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Service>>($"{BASE_URL}");
            return response;
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Service>($"{BASE_URL}/{id}");
        }

        public async Task<Service> CreateService(Service Service)
        {
            var response =  await _httpClient.PostAsJsonAsync($"{BASE_URL}", Service); 
            if(response.IsSuccessStatusCode)
            {
                var createdService = await response.Content.ReadFromJsonAsync<Service>();
                return createdService;
            }
           return null;
        }     

        public async Task<Service> UpdateService(int id, Service Service)
        {
            var request = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{id}", Service);
            var response = request;
            if (response.IsSuccessStatusCode)
            {
                var updateService = await response.Content.ReadFromJsonAsync<Service>();
                return updateService;
            }
            return null;
         }

        public async Task<bool> DeleteService(int id)
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
