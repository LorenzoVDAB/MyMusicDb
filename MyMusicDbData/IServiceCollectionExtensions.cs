using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusicDbData.Models;

namespace MyMusicDbData;

public static class IServiceCollectionExtensions {
    //Extensions for building the needed services 
    public static void ConfigureData(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("MyMusicDbConnection");
        services.AddDbContext<MyMusicDbContext>(options => options.UseSqlServer(connectionString));
    }
}
