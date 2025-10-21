
namespace Login.Api.Login.Register;

public record RegisterUserCommand(string UserName, string Password, string Role, DateTimeOffset Created_At, DateTimeOffset Updated_At, bool IsActive) : ICommand<RegisterUserResult>;
public record RegisterUserResult(Guid Id);

public class RegisterUserHandler(LoginDbContext dbContext) : ICommandHandler<RegisterUserCommand, RegisterUserResult>
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
