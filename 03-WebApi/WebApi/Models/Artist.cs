using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [NotMapped]
        public IFormFile Image { get; set; } = null!;

        public ICollection<Album> Albums { get; set; } = null!;
        public ICollection<Song> Songs { get; set; } = null!;
    }
}
