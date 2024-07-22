using Microsoft.EntityFrameworkCore;

using PlayGround.API.Models;

namespace PlayGround.API.Data;

public class PlayGroundDbContext : DbContext
{
	public DbSet<Poster> Posters => Set<Poster>();
	public DbSet<ImageInfo> ImageInfos => Set<ImageInfo>();

	public PlayGroundDbContext(DbContextOptions<PlayGroundDbContext> options)
		: base(options)
	{

	}
}