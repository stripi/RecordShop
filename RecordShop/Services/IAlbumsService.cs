
namespace RecordShop.Services
{
    public interface IAlbumsService
    {
        void AddAlbum(Album album);
        bool DeleteAlbum(int id);
        List<Album> FetchAlbumByArtist(string artist);
        List<Album> FetchAlbumByGenre(string genre);
        Album FetchAlbumById(int id);
        Album FetchAlbumByName(string name);
        List<Album> FetchAlbumByYear(int year);
        List<Album> FetchAllAlbums();
        bool UpdateAlbum(Album album, int id);
    }
}