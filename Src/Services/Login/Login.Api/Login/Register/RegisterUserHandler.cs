
namespace Login.Api.Login.Register;

public record RegisterUserCommand(string UserName, string Password, string Role, DateTimeOffset Created_At, DateTimeOffset Updated_At, bool IsActive) : ICommand<RegisterUserResult>;
public record RegisterUserResult(Guid Id);

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Name is required for update");
        RuleFor(X => X.Password).NotEmpty().WithMessage("Password is required for update");
        RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required for update");
        RuleFor(x => x.Updated_At).NotEmpty().WithMessage("Time is requird for update");
    }
}
internal class RegisterUserHandler(LoginDbContext dbContext) : ICommandHandler<RegisterUserCommand, RegisterUserResult>
{
    public async Task<RegisterUserResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var details = command.Adapt<UserDetail>();
        details.Id = Guid.NewGuid();
        dbContext.Add(details);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new RegisterUserResult(details.Id);
    }
}
