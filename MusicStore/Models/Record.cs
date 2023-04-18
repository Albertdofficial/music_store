namespace MusicStore.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public int Year { get; set; }
    }
}
