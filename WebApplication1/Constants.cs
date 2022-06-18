namespace WebApplication1 {
    public class Constants {
        public static string baseurl = "https://shazam.p.rapidapi.com";
        public static string baseurlDownload = "https://youtube-mp36.p.rapidapi.com";
        public static string host = "shazam.p.rapidapi.com";
        public static string hostDownload = "youtube-mp36.p.rapidapi.com";
        public static string apikey = "09c3e97749msh7b597fe78a99047p1801b2jsn405b90f3ea2f";

        public static string trackId; // TracksController/AddToPlaylist & PlaylistsController/AddTrack
        public static List<int> tracksCount; // TracksController/Artists & Tracks/Artists.cshtml
    }
}
