namespace BuildingBlocks.Exceptions;

public class ObjectDoNotMatchException:Exception
{
    public ObjectDoNotMatchException(string message) : base(message)
    {

    }

    public ObjectDoNotMatchException(string message, object key) : base($"Entity\"{message}\"({key}) password do not match.")
    {
    }
}
