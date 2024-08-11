using salesAdmin.Models;

namespace salesAdmin.Repository.Interfaces;

public interface IUserRepository
{
    Task CreateUser(User user);
    Task<User?> GetUser(string email);
    Task<bool> UserExists(string email);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}
