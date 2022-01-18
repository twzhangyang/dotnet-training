namespace WebApi.Artist.Request
{
    public class AddArtistRequest
    {
        public AddArtistRequest()
        {
            Songs = new List<AddSongRequest>();
        }

        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;
        public List<AddSongRequest> Songs { get; set; }

        public class AddSongRequest
        {
            public AddSongRequest()
            {
                IsFeatured = false;
            }

            public string Title { get; set; } = null!;
            public string Duration { get; set; } = null!;
            public DateTime UploadedDate { get; set; }
            public bool IsFeatured { get; set; }
        }
    }
}
