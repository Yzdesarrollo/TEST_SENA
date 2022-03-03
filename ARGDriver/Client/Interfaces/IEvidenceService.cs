using ARGDriver.Shared.Models.Services;

namespace ARGDriver.Client.Interfaces
{
    public interface IEvideneServices
    {
        Task<List<Evidences>> GetAllInsurers();
        Task<Evidences> GetInsurerById(int id);
        Task<Evidences> CreateInsurer(Evidences insurer);
        Task<Evidences> UpdateInsurer(int id, Evidences insurer);
        Task<bool> DeleteInsurer(int id);
    }
}
