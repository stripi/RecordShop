
namespace RecordShop.Models
{
    public interface IAlbumsModel
    {
        void AddAlbum(Album album);
        bool DeleteAlbum(int id);
        Album FetchAlbumById(int id);
        Album FetchAlbumByName(string name);
        List<Album> FetchAlbumsByArtist(string artist);
        List<Album> FetchAlbumsByGenre(string genre);
        List<Album> FetchAlbumsByYear(int year);
        List<Album> FetchAllAlbums();
        bool UpdateAlbum(Album album, int id);
    }
}