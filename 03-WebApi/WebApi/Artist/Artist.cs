using WebApi.Models;

namespace WebApi.Artist
{
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;
        public byte[] Image { get; set; } = null!;

        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
    }
}
