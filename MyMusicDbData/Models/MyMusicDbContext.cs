using Microsoft.EntityFrameworkCore;

namespace MyMusicDbData.Models;

public class MyMusicDbContext : DbContext {
    public DbSet<Album> Albums { get; set; } 
    public DbSet<Artist> Artists { get; set; } 
    public DbSet<Track> Tracks { get; set; }

    public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options) { }

}
