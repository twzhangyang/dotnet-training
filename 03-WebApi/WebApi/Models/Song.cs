﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Song
    {
        public Song()
        {
            IsFeatured = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public DateTime UploadedDate { get; set; }
        public bool IsFeatured { get; set; }

        public byte[] Image { get; set; } = null!;

        public byte[] AudioFile { get; set; } = null!;
        public Artist.Artist Artist { get; set; } = null!;

        public Album Album { get; set; } = null!;
    }
}
