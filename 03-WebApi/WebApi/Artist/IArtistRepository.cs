using Microsoft.EntityFrameworkCore;
using WebApi.Repository;

namespace WebApi.Artist;

public interface IArtistRepository
{
    Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize);

    Task<Artist?> GetArtist(Guid id);

    Task<Artist> Save(Artist artist);
}

public class ArtistRepository : IArtistRepository
{
    private readonly MusicDbContext _dbContext;

    public ArtistRepository(MusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize)
    {
        var currentPageNumber = pageNumber ?? 1;
        var currentPageSize = pageSize ?? 10;
        return await _dbContext.Artists
            .Skip((currentPageNumber - 1) * currentPageSize)
            .Take(currentPageSize)
            .ToListAsync();
    }

    public async Task<Artist?> GetArtist(Guid id)
    {
        return await _dbContext.Artists
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Artist> Save(Artist artist)
    {
        await _dbContext.Artists.AddAsync(artist);
        await _dbContext.SaveChangesAsync();
        return artist;
    }
}
