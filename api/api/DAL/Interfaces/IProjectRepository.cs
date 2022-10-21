using api.DBModels;

namespace api.DAL.Interfaces
{
  public interface IProjectRepository
  {
    public Task<List<Project>> GetProjects();

    public Task<Project?> GetProject(int projectId);

    public Task AddUser(int projectId, User user);

    public Task RemoveUser(int projectId, User user);
  }
}
