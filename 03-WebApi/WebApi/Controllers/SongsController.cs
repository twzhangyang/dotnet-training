﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly MusicDbContext _dbContext;
        public SongsController(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            var imageUrl = await FileUploader.UploadImage(song.Image);
            song.ImageUrl = imageUrl;
            var audioUrl = await FileUploader.UploadFile(song.AudioFile);
            song.AudioUrl = audioUrl;
            song.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var songs = await (from song in _dbContext.Songs
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   ImageUrl = song.ImageUrl,
                                   AudioUrl = song.AudioUrl
                               }).ToListAsync();
            return Ok(songs.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               where song.IsFeatured == true
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   ImageUrl = song.ImageUrl,
                                   AudioUrl = song.AudioUrl
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               orderby song.UploadedDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   ImageUrl = song.ImageUrl,
                                   AudioUrl = song.AudioUrl
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await (from song in _dbContext.Songs
                               where song.Title.StartsWith(query)
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   ImageUrl = song.ImageUrl,
                                   AudioUrl = song.AudioUrl
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }

    }
}
