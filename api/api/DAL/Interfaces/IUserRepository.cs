using api.DBModels;
using api.ViewModels;

namespace api.DAL.Interfaces
{
  public interface IUserRepository
  {
    public List<User> GetUsers();

    public void AddUser(UserModel userModel);

    public void EditUser(UserModel userModel);

    public void DeleteUser(int id);
  }
}
