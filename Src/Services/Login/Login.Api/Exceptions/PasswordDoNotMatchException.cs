using BuildingBlocks.Exceptions;

namespace Login.Api.Exceptions;

public class PasswordDoNotMatchException:ObjectDoNotMatchException
{
    public PasswordDoNotMatchException(Guid Id) : base("User",Id)
    {

    }
}
