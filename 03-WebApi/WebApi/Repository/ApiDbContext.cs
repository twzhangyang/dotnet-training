using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
    }
}
