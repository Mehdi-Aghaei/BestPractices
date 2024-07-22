using PlayGround.API.Data;
using PlayGround.API.Models;

namespace PlayGround.API.Endpoints;

public static class ImagesEndpoint
{

    public static RouteGroupBuilder MapImages(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/images");
        group.WithTags("Images");

        group.MapPost("/",async (ImageInfo image, PlayGroundDbContext dbContext) => 
        {
            var p = new ImageInfo() { Id = image.Id, SavedName= $"1{image.SavedName}",};
            dbContext.Add(p);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/images/{image.Id}",image);
        });

        return group;
    }
}