using Microsoft.EntityFrameworkCore;
using PlayGround.API.Models;

namespace PlayGround.API.Data;

public class PlayGroundDbContext(DbContextOptions<PlayGroundDbContext> options) : DbContext(options)
{
    public DbSet<Poster> Posters => Set<Poster>();
    public DbSet<ImageInfo> ImageInfos => Set<ImageInfo>();
}