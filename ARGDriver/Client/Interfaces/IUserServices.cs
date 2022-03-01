using ARGDriver.Shared.Models.Settings;

namespace ARGDriver.Client.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int id);
    }
}
