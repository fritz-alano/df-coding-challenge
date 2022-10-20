using FluentValidation;
using System;

namespace api.ViewModels
{
  public class UserModel
  {
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
  }

  public class UserModelValidator : AbstractValidator<UserModel>
  {
    public UserModelValidator()
    {
      RuleFor(x => x.FirstName).Length(1, 30);
      RuleFor(x => x.LastName).Length(1, 30);
      RuleFor(x => x.Email).EmailAddress();
    }
  }
}
