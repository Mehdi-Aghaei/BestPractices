using Microsoft.EntityFrameworkCore;
using PlayGround.API.Models;

namespace PlayGround.API.Data;

public class PlayGroundDbContext : DbContext
{
    public DbSet<Poster> Todos => Set<Poster>();
    public DbSet<ImageInfo> Friends => Set<ImageInfo>();

    public PlayGroundDbContext(DbContextOptions<PlayGroundDbContext> options)
        : base(options)
    {

    }
}