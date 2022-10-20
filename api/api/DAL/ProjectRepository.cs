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

  public List<Project> GetProjects()
  {
    using var context = new ApiContext();
    return (context.Projects
      .Include(x => x.Users)
      .ToList());
  }

  public void AddUser(int projectId, int userId)
  {
    using var context = new ApiContext();
    var project = context.Projects
        .Include(x => x.Users)
        .Where(x => x.Id == projectId).FirstOrDefault();
    var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

    project.Users.Add(user);
    context.SaveChanges();
  }

  public void RemoveUser(int projectId, int userId)
  {
    using var context = new ApiContext();
    var project = context.Projects
        .Include(x => x.Users)
        .Where(x => x.Id == projectId).FirstOrDefault();
    var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

    project.Users.Remove(user);
    context.SaveChanges();
  }
}
