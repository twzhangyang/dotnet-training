using WebApi.Artist.Request;

namespace WebApi.Artist;

public interface IArtistService
{
    Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize);

    Task<Artist?> GetArtist(Guid id);

    Task<Artist> Save(AddArtistRequest artist);
}

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;

    public ArtistService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    public Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize)
    {
        return _artistRepository.GetArtists(pageNumber, pageSize);
    }

    public Task<Artist?> GetArtist(Guid id)
    {
        return _artistRepository.GetArtist(id);
    }

    public Task<Artist> Save(AddArtistRequest artist)
    {
        return _artistRepository.Save(artist.ToArtist());
    }
}
