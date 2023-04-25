﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicDbData.Models {
    public class MyMusicDbContext : DbContext {
        public static IConfigurationRoot configuration { get; set; } 
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; } 
        public DbSet<Track> Tracks { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            configuration = new ConfigurationBuilder()
                        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MyMusicDbApp"))
                        .AddJsonFile("appsettings.json", false)
                        .Build();
        }
    }
}
