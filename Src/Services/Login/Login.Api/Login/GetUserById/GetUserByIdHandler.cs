
using Login.Api.Exceptions;

namespace Login.Api.Login.GetUserById;


public record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResult>;
public record GetUserByIdResult(UserDetail UserDetail);

public class GetUserByIdEndpoint(LoginDbContext dbContext) : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
{
    public async Task<GetUserByIdResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDetail = await dbContext.userDetails.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (userDetail == null)
        {
            throw new UserNotFoundException(request.Id);
        }
        return new GetUserByIdResult(userDetail);
    }
}