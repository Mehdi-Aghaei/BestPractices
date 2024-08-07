﻿using PlayGround.API.Data;

namespace PlayGround.API.Endpoints;

public static class PostersEndpoint
{
	public static RouteGroupBuilder MapPosters(this IEndpointRouteBuilder route)
	{
		var group = route.MapGroup("/posters");
		group.WithTags("Posters");

		group.MapGet("/", (PlayGroundDbContext dbContext) =>
		{
			return dbContext.Posters;
		});

		return group;
	}
}
