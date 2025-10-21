
namespace Login.Api.Login.DeleteUser;

public record DeleteUserCommand(Guid Id):ICommand<DeleteUserResult>;
public record DeleteUserResult(bool Success);

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id field is required");
    }
}

internal class DeleteUserHandler(LoginDbContext dbContext) : ICommandHandler<DeleteUserCommand, DeleteUserResult>
{
    public async Task<DeleteUserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.userDetails.FindAsync(command.Id,cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        dbContext.userDetails.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteUserResult(true);
       
    }
}
