using Microsoft.AspNetCore.Mvc;
using RecordShop.Models;
using RecordShop.Services;

namespace RecordShop.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumsService _albumsService;

        public AlbumsController(AlbumsService albumService)
        {
            _albumsService = albumService;
        }


        [HttpGet("/Albums")]
        public IActionResult FetchAllAlbums()
        {
            return Ok(_albumsService.FetchAllAlbums());
        }
        [HttpGet("/Albums/{id}")]
        public IActionResult FetchAlbumById(int id)
        {
            Album? foundAlbum = _albumsService.FetchAlbumById(id);

            if (foundAlbum == null)
            {
                return NotFound($"Album with ID {id} could not be found.");
            }
            return Ok(foundAlbum);
        }
        [HttpPost("/Albums/Name")]
        public IActionResult FetchAlbumByName(string name)
        {
            Album? foundAlbum = _albumsService.FetchAlbumByName(name);

            if (foundAlbum == null)
            {
                return NotFound($"No album found with name '{name}'");
            }
            return Ok(foundAlbum);
        }
        [HttpPost("/Albums/Artist")]
        public IActionResult FetchAlbumByArtist(string artist)
        {
            List<Album>? foundAlbums = _albumsService.FetchAlbumByArtist(artist);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No artist found with name '{artist}'");
            }
            return Ok(foundAlbums);

        }
        [HttpPost("/Albums/Genre")]
        public IActionResult FetchAlbumByGenre(string genre)
        {
            List<Album>? foundAlbums = _albumsService.FetchAlbumByGenre(genre);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No albums found for genre '{genre}'");
            }
            return Ok(foundAlbums);

        }
        [HttpGet("/Albums/Year/{year}")]
        public IActionResult FetchAlbumByYear(int year)
        {
            List<Album>? foundAlbums = _albumsService.FetchAlbumByYear(year);

            if (foundAlbums == null || foundAlbums.Count == 0)
            {
                return NotFound($"No albums released in {year} could be found.");
            }
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
