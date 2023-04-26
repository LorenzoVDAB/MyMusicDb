using Microsoft.EntityFrameworkCore;

namespace MyMusicDbData.Models;

public class MyMusicDbContext : DbContext {
    public DbSet<Album> Albums { get; set; } 
    public DbSet<Artist> Artists { get; set; } 
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Band> Bands { get; set; } 

    public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Artist>(artist => {
            artist.Property(a => a.Country).HasMaxLength(50);
            artist.Property(a => a.Name).HasMaxLength(50);
        });
        modelBuilder.Entity<Track>(track => {
            track.Property(a => a.Title).HasMaxLength(50);
        });
        modelBuilder.Entity<Album>(album => {
            album.Property(a => a.Title).HasMaxLength(50);
        });
    }
}
