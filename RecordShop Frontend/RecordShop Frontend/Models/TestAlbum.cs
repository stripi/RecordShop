using RecordShop;

public class TestAlbum
{
    public static Album testAlbum1 = new Album { Id = 1, Name = "Test Album", Artist = "TestMan", Genre = "LOFI", Year = 1999, Stock = 1 };
    public static Album testAlbum2 = new Album { Id = 2, Name = "Test Album The Sequel", Artist = "TestMan's Brother", Genre = "LOFI", Year = 1999, Stock = 0 };

    public static List<Album> albumList = new List<Album>() { testAlbum1, testAlbum2 };
    
}

