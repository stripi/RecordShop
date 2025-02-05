﻿using RecordShop.Models;

namespace RecordShop.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsModel _albumsModel;

        public AlbumsService(IAlbumsModel albumsModel)
        {
            _albumsModel = albumsModel;
        }

        public List<Album> FetchAllAlbums()
        {
            return _albumsModel.FetchAllAlbums();
        }

        public Album FetchAlbumById(int id)
        {
            return _albumsModel.FetchAlbumById(id);
        }
        public Album FetchAlbumByName(string name)
        {
            return _albumsModel.FetchAlbumByName(name);
        }
        public List<Album> FetchAlbumByArtist(string artist)
        {
            return _albumsModel.FetchAlbumsByArtist(artist);
        }
        public List<Album> FetchAlbumByYear(int year)
        {
            return _albumsModel.FetchAlbumsByYear(year);
        }
        public List<Album> FetchAlbumByGenre(string genre)
        {
            return _albumsModel.FetchAlbumsByGenre(genre);
        }
        public void AddAlbum(Album album)
        {
            _albumsModel.AddAlbum(album);
        }
        public bool DeleteAlbum(int id)
        {
            return _albumsModel.DeleteAlbum(id);
        }
        public bool UpdateAlbum(Album album, int id)
        {
            return _albumsModel.UpdateAlbum(album, id);
        }
    }
}
