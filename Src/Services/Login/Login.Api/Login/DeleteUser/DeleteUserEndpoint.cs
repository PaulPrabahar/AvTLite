
namespace Login.Api.Login.DeleteUser;

//public record DeleteUserRequest(Guid Id, bool IsActive);
public record DeleteUserResponse(bool Success);

public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/user/{Id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteUserCommand(Id));
            var response = result.Adapt<DeleteUserResponse>();
            return Results.Ok(response);
        }).WithName("deleteUser")
            .Produces<GetUserResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete User")
            .WithDescription("Delete User");
    }
}
