using ARGDriver.Shared.Models.Settings;

namespace ARGDriver.Client.Interfaces
{
    public interface IRolServices
    {
        Task<List<Rol>> GetAllRoles();
        Task<Rol> GetRolById(int id);
        Task<Rol> CreateRol(Rol rol);
        Task<Rol> UpdateRol(int id,Rol rol);
        Task<bool> DeleteRol(int id);
    }
}
