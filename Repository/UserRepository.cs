using Microsoft.EntityFrameworkCore;
using salesAdmin.Data;
using salesAdmin.Models;
using salesAdmin.Repository.Interfaces;

namespace salesAdmin.Repository;

public class UserRepository: IUserRepository
{
private readonly ApplicationDbContext context;

    public UserRepository(ApplicationDbContext context){
        this.context = context;
    }

    public async Task CreateUser(User user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
    }

    public async Task<User?> GetUser(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Mail == email);
    }

    public async Task UpdateUser(User user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task<bool> UserExists(string email)
    {
        return await context.Users.AnyAsync(u => u.Mail == email);
    }
}
