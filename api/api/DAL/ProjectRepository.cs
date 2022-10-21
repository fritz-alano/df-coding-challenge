using api.DBModels;
using api.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.DAL;

public class ProjectRepository : IProjectRepository
{
  public ProjectRepository()
  {
    // insert some projects data since we're only exposing ability to add/remove users
    using var context = new ApiContext();
    if (!context.Projects.Any())
    {
      var projects = new List<Project>
      {
        new Project { Name = "SoftwareVerse" },
        new Project { Name = "Tesla" },
        new Project { Name = "Developistic" }
      };
      context.Projects.AddRange(projects);
      context.SaveChanges();
    }
  }

  public Task<List<Project>> GetProjects()
  {
    using var context = new ApiContext();
    return context.Projects
      .Include(x => x.Users)
      .ToListAsync();
  }

  public Task<Project?> GetProject(int projectId)
  {
    using var context = new ApiContext();
    return context.Projects
      .Where(x => x.Id == projectId)
      .Include(x => x.Users)
      .FirstOrDefaultAsync();
  }


  public Task AddUser(int projectId, User user)
  {
    using var context = new ApiContext();
    var project = context.Projects
        .Include(x => x.Users)
        .Where(x => x.Id == projectId)
        .First();

    project.Users.Add(user);
    return context.SaveChangesAsync();
  }

  public Task RemoveUser(int projectId, User user)
  {
    using var context = new ApiContext();
    var project = context.Projects
        .Include(x => x.Users)
        .Where(x => x.Id == projectId)
        .First();

    var el = project.Users.Where(x => x.Id == user.Id).First();
    project.Users.Remove(el);
    return context.SaveChangesAsync();
  }
}
