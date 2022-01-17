namespace WebApi.Artist;

public static class ArtistRegister
{
   public static IServiceCollection RegisterArtist(this IServiceCollection services)
   {
      services.AddScoped<IArtistRepository, ArtistRepository>();
      services.AddScoped<IArtistService, ArtistService>();
      return services;
   }
}
