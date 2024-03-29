﻿using Microsoft.AspNetCore.Mvc;
using WebApi.Artist.Request;

namespace WebApi.Artist
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpPost]
        public async Task<Artist> Post(AddArtistRequest artist)
        {
           var newArtist =  await _artistService.Save(artist);
           return newArtist;
        }

        // api/artists
        [HttpGet]
        public async Task<List<Artist>> GetArtists(int? pageNumber, int? pageSize)
        {
            return await _artistService.GetArtists(pageNumber, pageSize);
        }

        [HttpGet("Artist")]
        public async Task<Artist?> ArtistDetails(Guid artistId)
        {
            return await _artistService.GetArtist(artistId);
        }
    }
}
