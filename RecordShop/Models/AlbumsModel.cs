namespace RecordShop.Models
{
    public class AlbumsModel
    {
        RecordShopDbContext _dbContext = new RecordShopDbContext();

        public List<Album> FetchAllAlbums()
        {
            return _dbContext.Albums.Where(x => x.Stock > 0).ToList();
        }

        public Album FetchAlbumById(int id)
        {
            return _dbContext.Albums.FirstOrDefault(x => x.Id == id);
        }

        public List<Album> FetchAlbumsByArtist(string artist)
        {
            return _dbContext.Albums.Where(x => x.Artist == artist).ToList();
        }

        public List<Album> FetchAlbumsByYear(int year)
        {
            return _dbContext.Albums.Where(x => x.Year == year).ToList();
        }

        public List<Album> FetchAlbumsByGenre(string genre)
        {
            return _dbContext.Albums.Where(x => x.Genre == genre).ToList();
        }

        public Album FetchAlbumByName(string name)
        {
            return _dbContext.Albums.FirstOrDefault(x => x.Name.Contains(name));
        }

        public void AddAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public bool UpdateAlbum(Album album, int id)
        {
            if (DeleteAlbum(id))
            {
            AddAlbum(album);
            return true;
            }
            return false;
        }

        public bool DeleteAlbum(int id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Albums.FirstOrDefault(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

    }
}
