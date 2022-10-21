using api.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/project")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public ProjectController(IProjectRepository projectRepository, IUserRepository userRepository)
    {
      _projectRepository = projectRepository;
      _userRepository = userRepository;
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetProjects()
    {
      return Ok(await _projectRepository.GetProjects());
    }

    [HttpPost]
    [Route("add-user")]
    public async Task<IActionResult> AddUser(int projectId, int userId)
    {
      var project = await _projectRepository.GetProject(projectId);
      var user = await _userRepository.GetUser(userId);

      if (project == null || user == null)
        return BadRequest("Invalid project or user data");

      if (project.Users.Any(x => x.Id == user.Id))
        return BadRequest("User already belongs to the project");

      await _projectRepository.AddUser(project.Id, user);
      return Ok();
    }

    [HttpPost]
    [Route("remove-user")]
    public async Task<IActionResult> RemoveUser(int projectId, int userId)
    {
      var project = await _projectRepository.GetProject(projectId);
      var user = await _userRepository.GetUser(userId);

      if (project == null || user == null)
        return BadRequest("Invalid project or user data");

      if (!project.Users.Any(x => x.Id == user.Id))
        return BadRequest("User doesn't belong to the project");

      await _projectRepository.RemoveUser(projectId, user);
      return Ok();
    }
  }
}
