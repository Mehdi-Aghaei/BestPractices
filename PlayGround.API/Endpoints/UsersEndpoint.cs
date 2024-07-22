using PlayGround.API.Data;
using PlayGround.API.Models;

namespace PlayGround.API.Endpoints;

public static class UsersEndpoint
{
    public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/users");
        group.WithTags("Users");


        group.MapPost("/", async (AppUser user, PlayGroundDbContext dbContext) => 
        {
            dbContext.Add(new AppUser { Id = user.Id, Name = user.Name, Age = user.Age});
            await dbContext.SaveChangesAsync();
				
            return Results.Created($"/users/{user.Id}",user);
        });

        return group;
    }
}