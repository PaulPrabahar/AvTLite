
namespace Login.Api.Login.UpdateUser;

public record UpdateUserRequest(Guid Id, string UserName, string Password, string Role, DateTimeOffset Created_At, DateTimeOffset Updated_At, bool IsActive);
public record UpdateUserResponse(bool Success);

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/user", async (UpdateUserRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateUserCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateUserResponse>();
            return Results.Ok(response);
        }).WithName("UpdateUser")
            .Produces<GetUserResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update User")
            .WithDescription("Update User");
    }
}
