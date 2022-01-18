using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }

        public DbSet<Song.Song> Songs { get; set; } = null!;
        public DbSet<Artist.Artist> Artists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist.Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistForeignKey);
        }
    }
}
