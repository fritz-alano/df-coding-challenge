using api.Controllers;
using api.DAL.Interfaces;
using api.DBModels;
using api.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace api.UnitTests
{
  public class UserControllerTests
  {
    private readonly Mock<IValidator<UserModel>> _validator;

    public UserControllerTests()
    {
      _validator = new Mock<IValidator<UserModel>>();
    }

    [Fact]
    public async Task GetUsers_ReturnOk()
    {
      var repository = new Mock<IUserRepository>();
      repository.Setup(repo => repo.GetUsers())
       .Returns(MockUsers());

      var controller = new UserController(repository.Object, _validator.Object);
      IActionResult result = await controller.GetUsers();
      var okResult = Assert.IsType<OkObjectResult>(result);

      var json = JsonConvert.SerializeObject(okResult.Value);
      var values = JsonConvert.DeserializeObject<List<UserModel>>(json);

      Assert.Equal(GenerateUsers().Count, values.Count);
    }

    [Fact]
    public async Task DeleteUser_IdIsZero_ReturnNotFound()
    {
      var repository = new Mock<IUserRepository>();

      var controller = new UserController(repository.Object, _validator.Object);
      IActionResult result = await controller.DeleteUser(0);

      Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteUser_IdIsNotZero_ReturnOk()
    {
      var repository = new Mock<IUserRepository>();
      repository.Setup(repo => repo.GetUser(1))
       .Returns(MockUser());

      var controller = new UserController(repository.Object, _validator.Object);
      IActionResult result = await controller.DeleteUser(1);
      Assert.IsType<OkResult>(result);
    }

    private static Task<List<User>> MockUsers()
    {
      return Task.Run(() => GenerateUsers());
    }

    private static Task<User?> MockUser()
    {
      return Task.Run(() => GenerateUser());
    }

    private static List<User> GenerateUsers()
    {
      return new List<User>
      {
        new User()
        {
          Id = 1,
          FirstName = "Bob",
          LastName = "Doe",
          Email = "bobdoe@noreply.com"
        },
        new User()
        {
          Id = 2,
          FirstName = "Jane",
          LastName = "Smith",
          Email = "janesmith@noreply.com"
        }
      };
    }

    private static User? GenerateUser()
    {
      return
        new User()
        {
          Id = 1,
          FirstName = "Bob",
          LastName = "Doe",
          Email = "bobdoe@noreply.com"
        };
    }
  }
}
