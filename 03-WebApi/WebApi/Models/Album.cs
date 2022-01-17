﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public Artist.Artist Artist { get; set; } = null!;
        public List<Song> Songs { get; set; }
    }
}
