using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Tests.TestSeeds;

public static class TestSeedsInitializer
{
    public static void Initialize(MusicDbContext dbContext)
    {
        var image = Encoding.ASCII.GetBytes("image");
        var song = new Song()
        {
            Duration = "duration",
            Image = image,
            Title = "title",
            IsFeatured = true,
            UploadedDate = DateTime.Now,
            AudioFile = Encoding.ASCII.GetBytes("audio")
        };
        var artist = new WebApi.Artist.Artist
        {
            Gender = "Male",
            Name = "Jay",
            Image = image,
            Songs = new List<Song>() { song }
        };

        dbContext.Add(artist);
        dbContext.SaveChanges();
    }
}
