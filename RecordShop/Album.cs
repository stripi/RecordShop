namespace RecordShop
{

    public enum GenreType
    {
        POP,
        ROCK,
        LOFI
    }
    public class Album
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }



    }
}
