using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusicDbData.Models;
using MyMusicDbData.Repositories.Interfaces;
using MyMusicDbData.Repositories.SQL;

namespace MyMusicDbData;

public static class IServiceCollectionExtensions {
    //Extensions for building the needed services, needed to prevent App from having to access Data directly
    public static void ConfigureData(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("MyMusicDbConnection");
        services.AddDbContext<MyMusicDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IArtistsRepository, SQLArtistsRepository>(); 
        services.AddScoped<ITracksRepository, SQLTracksRepository>(); 
    }
}
