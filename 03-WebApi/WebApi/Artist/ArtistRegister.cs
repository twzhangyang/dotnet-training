namespace WebApi.Artist;

public static class ArtistRegister
{
   public static IServiceCollection RegisterArtist(this IServiceCollection services)
   {
      services.AddScoped<IArtistRepository, ArtistRepository>();
      return services;
   }
}
