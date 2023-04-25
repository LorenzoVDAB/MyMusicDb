using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusicDbData;

namespace MyMusicDbServices;

//Static class for extending the functionality of the injected services using objects that implement IConfiguration
public static class IServiceCollectionExtensions {
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration) {
        services.ConfigureData(configuration);
    }
}
