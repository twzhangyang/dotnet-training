using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int ArtistId { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; } = null!;

        public ICollection<Song> Songs { get; set; } = null!;
    }
}
