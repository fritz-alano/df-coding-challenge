using api.DBModels;
using api.ViewModels;

namespace api.DAL.Interfaces
{
  public interface IUserRepository
  {
    public Task<List<User>> GetUsers();

    public Task<User?> GetUser(int userId);

    public Task AddUser(UserModel userModel);

    public Task EditUser(UserModel userModel);

    public Task DeleteUser(int id);
  }
}
