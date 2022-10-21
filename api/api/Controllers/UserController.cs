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
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UserModel> _validator;

    public UserController(IUserRepository userRepository, IValidator<UserModel> validator)
    {
      _userRepository = userRepository;
      _validator = validator;
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _userRepository.GetUsers();
      return Ok(users);
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddUser([FromBody] UserModel user)
    {
      ValidationResult result = _validator.Validate(user);

      if (!result.IsValid)
        return BadRequest("Invalid request");

      await _userRepository.AddUser(user);
      return Ok();
    }

    [HttpPost]
    [Route("edit")]
    public async Task<IActionResult> EditUser([FromBody] UserModel userModel)
    {
      ValidationResult result = _validator.Validate(userModel);

      if (!result.IsValid)
        return BadRequest("Invalid request");

      var user = await _userRepository.GetUser(userModel.Id);
      if (user == null)
        return NotFound();

      await _userRepository.EditUser(userModel);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      if (id == 0)
        return NotFound();

      var user = await _userRepository.GetUser(id);
      if (user == null)
        return NotFound();

      await _userRepository.DeleteUser(id);
      return Ok();
    }
  }
}


