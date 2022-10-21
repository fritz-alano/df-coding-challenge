using api.DAL.Interfaces;
using api.DBModels;
using api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api.DAL
{
  public class UserRepository : IUserRepository
  {
    public UserRepository()
    {
      // insert 1 user data 
      using var context = new ApiContext();
      if (!context.Users.Any())
      {
        context.Add(new User
        {
          FirstName = "admin",
          LastName = "-",
          Email = "admin@noreply.com"
        });
        context.SaveChanges();
      }
    }

    public Task<List<User>> GetUsers()
    {
      using var context = new ApiContext();
      return context.Users
        .ToListAsync();
    }

    public Task<User?> GetUser(int userId)
    {
      using var context = new ApiContext();
      return context.Users
        .Where(x => x.Id == userId)
        .FirstOrDefaultAsync();
    }

    public Task AddUser(UserModel userModel)
    {
      using var context = new ApiContext();
      context.Add(new User
      {
        FirstName = userModel.FirstName,
        LastName = userModel.LastName,
        Email = userModel.Email
      });
      return context.SaveChangesAsync();
    }

    public Task EditUser(UserModel userModel)
    {
      using var context = new ApiContext();
      var user = context.Users
        .Where(x => x.Id == userModel.Id)
        .First();
      user.FirstName = userModel.FirstName;
      user.LastName = userModel.LastName;
      user.Email = userModel.Email;
      return context.SaveChangesAsync();
    }

    public Task DeleteUser(int id)
    {
      using var context = new ApiContext();
      var user = context.Users
        .Where(x => x.Id == id)
        .First();
      context.Users.Remove(user);
      return context.SaveChangesAsync();
    }
  }
}
