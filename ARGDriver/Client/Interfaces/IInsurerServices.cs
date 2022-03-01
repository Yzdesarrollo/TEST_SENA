using ARGDriver.Shared.Models.Insurance;

namespace ARGDriver.Client.Interfaces
{
    public interface IInsurerServices
    {
        Task<List<Insurer>> GetAllInsurers();
        Task<Insurer> GetInsurerById(int id);
        Task<Insurer> CreateInsurer(Insurer insurer);
        Task<Insurer> UpdateInsurer(int id, Insurer insurer);
        Task<bool> DeleteInsurer(int id);
    }
}
