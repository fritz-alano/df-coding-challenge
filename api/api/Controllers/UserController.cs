using api.DAL.Interfaces;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet]
    [Route("get")]
    public ActionResult<List<UserModel>> Get()
    {
      var users = _userRepository.GetUsers();
      return Ok(users);
    }

    [HttpPost]
    [Route("add")]
    public void Post([FromBody] UserModel user)
    {
      _userRepository.AddUser(user);
    }

    [HttpPost]
    [Route("edit")]
    public void Edit([FromBody] UserModel user)
    {
      _userRepository.EditUser(user);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _userRepository.DeleteUser(id);
    }
  }
}


