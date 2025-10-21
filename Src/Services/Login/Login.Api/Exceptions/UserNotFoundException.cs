using BuildingBlocks.Exceptions;

namespace Login.Api.Exceptions;

public class UserNotFoundException:NotFoundException
{
    public UserNotFoundException(Guid Id) : base("User",Id)
    {

    }
}
