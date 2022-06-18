namespace WebApplication1.Models {
    public class Playlist {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int TracksCount { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
