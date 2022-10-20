using api.DAL.Interfaces;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/project")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    readonly IProjectRepository _projectRepository;
    public ProjectController(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }

    [HttpGet]
    [Route("get")]
    public ActionResult<List<ProjectModel>> Get()
    {
      return Ok(_projectRepository.GetProjects());
    }

    [HttpPost]
    [Route("add-user")]
    public void AddUser(int projectId, int userId)
    {
      _projectRepository.AddUser(projectId, userId);
    }

    [HttpPost]
    [Route("remove-user")]
    public void RemoveUser(int projectId, int userId)
    {
      _projectRepository.RemoveUser(projectId, userId);
    }
  }
}
