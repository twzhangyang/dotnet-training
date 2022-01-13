using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public DateTime UploadedDate { get; set; }
        public bool IsFeatured { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [NotMapped]
        public IFormFile AudioFile { get; set; } = null!;

        public string AudioUrl { get; set; } = null!;
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
