using FluentValidation;
using TravelAgencyApi.Domain.Users;

namespace TravelAgencyApi.Validators;

public class UserValidator : AbstractValidator<User>{
    public UserValidator(){
        RuleFor(u => u.User_Name).NotEmpty().WithMessage("The user name field is required!!!");

        RuleFor(u => u.Email).NotEmpty().WithMessage("The email field is required!!!").EmailAddress().WithMessage("The email field must contain a valid email!!!");

        RuleFor(u => u.Password).NotEmpty().WithMessage("The password field is required!!!").MinimumLength(6).WithMessage("The password field must be at least 6 charactes length!!!");

        RuleFor(u => u.Role).NotEmpty().WithMessage("The role field is required!!!");
    }
}