using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repository
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Artist.Artist> Artists { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // optionsBuilder.UseNpgsql("Host=localhost;Database=music_db;Username=music;Password=music123");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist.Artist>()
                .HasMany(a => a.Albums)
                .WithOne(album => album.Artist);

            modelBuilder.Entity<Artist.Artist>()
                .HasMany(a => a.Songs)
                .WithOne(song => song.Artist);

             modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(song => song.Album);
        }
    }
}
