
namespace Login.Api.Login.SignIn;

public record SignInCommand(Guid Id, string UserName, string Password):ICommand<SignInResult>;
public record SignInResult(bool Success);

public class SignInCommandValidator : AbstractValidator<SignInCommand> 
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id field is required");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName field is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password field is required");
    }
}

internal class SignInHandler(LoginDbContext dbContext) : ICommandHandler<SignInCommand, SignInResult>
{
    public async Task<SignInResult> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.userDetails.FindAsync(command.Id);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        if (user.Password != command.Password) 
        {
            throw new PasswordDoNotMatchException(command.Id);
        }

        return new SignInResult(true);
    }
}
