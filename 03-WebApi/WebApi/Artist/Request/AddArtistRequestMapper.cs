namespace WebApi.Artist.Request
{
    public static class AddArtistRequestMapper
    {
        public static Artist ToArtist(this AddArtistRequest request)
        {
            var artist = new Artist()
            {
                Gender = request.Gender,
                Name = request.Name,
                Image = new Byte[] { },
                Songs = request.Songs.Select(x => new Song.Song()
                {
                    Duration = x.Duration,
                    Title = x.Title,
                    IsFeatured = x.IsFeatured,
                    Image = new byte[] { },
                    AudioFile = new byte[] { },
                    UploadedDate = x.UploadedDate
                }).ToList()
            };

            return artist;
        }
    }
}
