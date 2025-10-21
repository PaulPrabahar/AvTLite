
namespace Login.Api.Login.GetUser;

public record GetUserQuery():IQuery<GetUserResult>;
public record GetUserResult(IEnumerable<UserDetail> UserDetails);
public class GetUserHandler(LoginDbContext dbContext) : IQueryHandler<GetUserQuery, GetUserResult>
{
    public async Task<GetUserResult> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var userDetails = await dbContext.userDetails.ToListAsync(cancellationToken);
        return new GetUserResult(userDetails);
    }
}
