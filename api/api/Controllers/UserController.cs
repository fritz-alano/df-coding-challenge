using api.DAL.Interfaces;
using api.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    readonly IUserRepository _userRepository;
    private IValidator<UserModel> _validator;

    public UserController(IUserRepository userRepository, IValidator<UserModel> validator)
    {
      _userRepository = userRepository;
      _validator = validator;
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
    public ActionResult Post([FromBody] UserModel user)
    {
      ValidationResult result = _validator.Validate(user);

      if (!result.IsValid)
        return BadRequest("Invalid request");

      _userRepository.AddUser(user);
      return Ok();
    }

    [HttpPost]
    [Route("edit")]
    public ActionResult Edit([FromBody] UserModel user)
    {
      ValidationResult result = _validator.Validate(user);

      if (!result.IsValid)
        return BadRequest("Invalid request");

      _userRepository.EditUser(user);
      return Ok();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _userRepository.DeleteUser(id);
    }
  }
}


