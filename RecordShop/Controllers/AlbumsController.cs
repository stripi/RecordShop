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
            return Ok(_albumsService.FetchAlbumById(id));
        }
        [HttpPost("/Albums/Name")]
        public IActionResult FetchAlbumByName(string name)
        {
            return Ok(_albumsService.FetchAlbumByName(name));
        }
        [HttpPost("/Albums/Artist")]
        public IActionResult FetchAlbumByArtist(string name)
        {
            return Ok(_albumsService.FetchAlbumByArtist(name));
        }
        [HttpPost("/Albums/Genre")]
        public IActionResult FetchAlbumByGenre(string name)
        {
            return Ok(_albumsService.FetchAlbumByGenre(name));
        }
        [HttpGet("/Albums/Year/{year}")]
        public IActionResult FetchAlbumByYear(int year)
        {
            return Ok(_albumsService.FetchAlbumByYear(year));
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
            _albumsService.DeleteAlbum(id);
            return Ok();
        }
        [HttpPost("/Albums/Manage/Update")]
        public IActionResult UpdateAlbum(Album album, int id)
        {
            _albumsService.UpdateAlbum(album, id);
            return Ok(album);
        }

    }
}
