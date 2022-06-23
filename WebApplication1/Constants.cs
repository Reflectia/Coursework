using WebApplication1.Models;

namespace WebApplication1 {
    public class Constants {
        public static string baseurl = "https://shazam.p.rapidapi.com";
        public static string baseurlDownload = "https://youtube-mp36.p.rapidapi.com";
        public static string baseurlTranslate = "https://google-translate20.p.rapidapi.com";
        public static string host = "shazam.p.rapidapi.com";
        public static string hostDownload = "youtube-mp36.p.rapidapi.com";
        public static string hostTranslate = "google-translate20.p.rapidapi.com";
        public static string apikey = "09c3e97749msh7b597fe78a99047p1801b2jsn405b90f3ea2f";
        public static string extraApikey = "fe06d045bcmshab3f2d069b80661p1c7992jsn8a782b976de0";

        public static string trackId; // TracksController/AddToPlaylist & PlaylistsController/AddTrack
        public static List<int> tracksCount; // TracksController/Artists & Tracks/Artists.cshtml
        public static Translation tranText; //TranslationController & Tracks/Details.cshtml
    }
}
