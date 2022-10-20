using api.DAL.Interfaces;
using api.DBModels;
using api.ViewModels;

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
    public List<User> GetUsers()
    {
      using var context = new ApiContext();
      var list = context.Users
          .ToList();
      return list;
    }

    public void AddUser(UserModel userModel)
    {
      using var context = new ApiContext();
      context.Add(new User
      {
        FirstName = userModel.FirstName,
        LastName = userModel.LastName,
        Email = userModel.Email
      });

      context.SaveChanges();
    }

    public void EditUser(UserModel userModel)
    {
      using var context = new ApiContext();
      var user = context.Users.Where(x => x.Id == userModel.Id)
        .FirstOrDefault();
      user.FirstName = userModel.FirstName;
      user.LastName = userModel.LastName;
      user.Email = userModel.Email;

      context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
      using var context = new ApiContext();
      var user = context.Users.Where(x => x.Id == id).FirstOrDefault();
      context.Users.Remove(user);
      context.SaveChanges();
    }
  }
}
