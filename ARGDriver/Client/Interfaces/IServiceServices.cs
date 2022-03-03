using ARGDriver.Shared.Models.Services;

namespace ARGDriver.Client.Interfaces
{
    public interface IServiceServices
    {
        Task<List<Service>> GetAllServices();
        Task<Service> GetServiceById(int id);
        Task<Service> CreateService(Service service);
        Task<Service> UpdateService(int id, Service Service);
        Task<bool> DeleteService(int id);
    }
}

