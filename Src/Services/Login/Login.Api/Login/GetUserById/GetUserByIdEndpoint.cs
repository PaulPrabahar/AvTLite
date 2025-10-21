using Login.Api.Login.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Login.GetUserById;

//public record GetUserByIdRequest();
public record GetUserByIdResponse(UserDetail userDetail);
public class GetUserByIdHandler : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/register/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetUserByIdQuery(id)); 
            var response = result.Adapt<GetUserByIdResponse>();
            return Results.Ok(response);
        }).WithName("GetUserById")
            .Produces<GetUserResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get User By Id")
            .WithDescription("Get User By Id");
    }
}
