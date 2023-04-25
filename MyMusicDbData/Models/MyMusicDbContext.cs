using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicDbData.Models {
    public class MyMusicDbContext : DbContext {
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!; 

        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           
        }
    }
}
