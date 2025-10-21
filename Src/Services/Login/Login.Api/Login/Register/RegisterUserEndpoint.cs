namespace Login.Api.Login.Register;

public record RegisterUserRequest(string UserName, string Password, string Role, DateTimeOffset Created_At, DateTimeOffset Updated_At, bool IsActive);
public record RegisterUserResponse(Guid Id);
public class RegisterUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (RegisterUserRequest request, ISender sender) =>
        {
            var command = request.Adapt<RegisterUserCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<RegisterUserResponse>();
            return Results.Created($"/register/{response.Id}", response);
        })
            .WithName("RegisterUser")
            .Produces<RegisterUserResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register User")
            .WithDescription("Register User");
    }
}
