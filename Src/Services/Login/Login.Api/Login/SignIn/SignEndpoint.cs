
namespace Login.Api.Login.SignIn;

public record SignInRequest(Guid Id, string UserName, string Password);
public record SignInResponse(bool Success);

public class SignEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/signin", async (SignInRequest request, ISender sender) =>
        {
            var command = request.Adapt<SignInCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<SignInResponse>();
            return Results.Ok(response);
        }).WithName("sign in")
            .Produces<GetUserResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Sign In")
            .WithDescription("Sign In");
    }
}
