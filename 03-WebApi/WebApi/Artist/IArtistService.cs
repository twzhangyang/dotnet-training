namespace WebApi.Artist;

public interface IArtistService
{
    Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize);

    Task<Artist?> GetArtist(Guid id);

    Task<Artist> Save(Artist artist);
}
