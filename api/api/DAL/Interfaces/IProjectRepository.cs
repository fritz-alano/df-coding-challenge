using api.DBModels;

namespace api.DAL.Interfaces
{
  public interface IProjectRepository
  {
    public List<Project> GetProjects();

    public void AddUser(int projectId, int userId);

    public void RemoveUser(int projectId, int userId);
  }
}
