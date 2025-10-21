
namespace Login.Api.Login.UpdateUser;

public record UpdateUserCommand(Guid Id,string UserName, string Password, string Role, DateTimeOffset Created_At, DateTimeOffset Updated_At, bool IsActive) :ICommand<UpdateUserResult>;
public record UpdateUserResult(bool Success);

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x =>x.Id).NotEmpty().WithMessage("Id field is required");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName field is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password field is required");
        RuleFor(x => x.Role).NotEmpty().WithMessage("Role field is required"); 
        RuleFor(x => x.IsActive).NotEmpty().WithMessage("IsActive field is required");
    }
}

public class UpdateUserHandler(LoginDbContext dbContext) : ICommandHandler<UpdateUserCommand,UpdateUserResult>
{
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.userDetails.FindAsync(command.Id,cancellationToken);

        if (user == null) 
        { 
            throw new UserNotFoundException(command.Id);
        }

        user.UserName = command.UserName;
        user.Password = command.Password;
        user.Role = command.Role;
        user.Updated_At = command.Updated_At;
        user.IsActive = command.IsActive;

        dbContext.Update(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateUserResult(true);
    }
}
