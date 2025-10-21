
namespace Login.Api.Login.GetUser;

//public record GetUserRequest();
public record GetUserResponce(IEnumerable<UserDetail> UserDetails);
public class GetUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/register", async (ISender sender) =>
        {
            var result = await sender.Send(new GetUserQuery());
            var responce = result.Adapt<GetUserResponce>();
            return Results.Ok(responce);

        }).WithName("GetUser")
            .Produces<GetUserResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get User")
            .WithDescription("Get User");
    }
}
