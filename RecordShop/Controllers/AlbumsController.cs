using Microsoft.AspNetCore.Mvc;
using RecordShop.Models;
using RecordShop.Services;
using Microsoft.Extensions.Caching.Memory;

namespace RecordShop.Controllers
{

    [ApiController]
    [Route("[controller]")]
    
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;
        private readonly IMemoryCache _cache;
        private readonly int cacheTime = 30;

        public AlbumsController(IAlbumsService albumService, IMemoryCache cache)
        {
            _albumsService = albumService;
            _cache = cache;
        }


        [HttpGet("/Albums")]
        public IActionResult FetchAllAlbums()
        {
            if (_cache.TryGetValue("FetchAllAlbums", out var albums))
            { 
                return Ok(albums);
            }
            _cache.Set("FetchAllAlbums", _albumsService.FetchAllAlbums(), new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });
            return Ok(_albumsService.FetchAllAlbums());
        }
        [HttpGet("/Albums/{id}")]
        public IActionResult FetchAlbumById(int id)
        {
            if (_cache.TryGetValue($"FetchAlbumById{id}", out var albums))
            {
                return Ok(albums);
            }

            Album? foundAlbum = _albumsService.FetchAlbumById(id);

            if (foundAlbum == null)
            {
                return NotFound($"Album with ID {id} could not be found.");
            }
            _cache.Set($"FetchAlbumById{id}", foundAlbum, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });
            return Ok(foundAlbum);
        }
        [HttpPost("/Albums/Name")]
        public IActionResult FetchAlbumByName(string name)
        {
            if (_cache.TryGetValue($"FetchAlbumByName{name}", out var albums))
            {
                return Ok(albums);
            }

            Album? foundAlbum = _albumsService.FetchAlbumByName(name);

            if (foundAlbum == null)
            {
                return NotFound($"No album found with name '{name}'");
            }
            _cache.Set($"FetchAlbumByName{name}", foundAlbum, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });

            return Ok(foundAlbum);
        }
        [HttpPost("/Albums/Artist")]
        public IActionResult FetchAlbumByArtist(string artist)
        {
            if (_cache.TryGetValue($"FetchAlbumByArtist{artist}", out var albums))
            {
                return Ok(albums);
            }

            List<Album>? foundAlbums = _albumsService.FetchAlbumByArtist(artist);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No artist found with name '{artist}'");
            }
            _cache.Set($"FetchAlbumByArtist{artist}", foundAlbums, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });

            return Ok(foundAlbums);

        }
        [HttpPost("/Albums/Genre")]
        public IActionResult FetchAlbumByGenre(string genre)
        {
            if (_cache.TryGetValue($"FetchAlbumByGenre{genre}", out var albums))
            {
                return Ok(albums);
            }

            List<Album>? foundAlbums = _albumsService.FetchAlbumByGenre(genre);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No albums found for genre '{genre}'");
            }

            _cache.Set($"FetchAlbumByGenre{genre}", foundAlbums, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });
            return Ok(foundAlbums);

        }
        [HttpGet("/Albums/Year/{year}")]
        public IActionResult FetchAlbumByYear(int year)
        {
            if (_cache.TryGetValue($"FetchAlbumByYear{year}", out var albums))
            {
                return Ok(albums);
            }

            List<Album>? foundAlbums = _albumsService.FetchAlbumByYear(year);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No albums released in {year} could be found.");
            }

            _cache.Set($"FetchAlbumByYear{year}", foundAlbums, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime) });
            return Ok(foundAlbums);

        }

        //[Authorize]
        [HttpPost("/Albums/Manage/Post")]
        public IActionResult PostAlbum(Album album)
        {
            _albumsService.AddAlbum(album);
            return Ok(album);
        }
        [HttpPost("/Albums/Manage/Delete")]
        public IActionResult DeleteAlbum(int id)
        {
            if (_albumsService.DeleteAlbum(id))
            {
            return Ok($"Album with ID {id} was deleted successfully.");
            }
            return NotFound($"No album with ID {id} could not be found.");
        }
        [HttpPost("/Albums/Manage/Update")]
        public IActionResult UpdateAlbum(Album album, int id)
        {
            if (_albumsService.UpdateAlbum(album, id))
            {
            return Ok(album);
            }
            return BadRequest($"No album with id {id} could not be found, or the data entered is not valid.");
        }

    }
}
