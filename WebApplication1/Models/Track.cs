using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models {
    public class Track {
        [Key]
        public string Key { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Background { get; set; }
        public string Coverart { get; set; }
        public string Genres { get; set; } 
        //рядки будуть розділятись /n
        public string Text { get; set; }
        public string Footer { get; set; }
        public string Caption { get; set; }
        public string Uri { get; set; }
        public int PlaylistId { get; set; }

        public Dictionary<string, string> lang = new Dictionary<string, string>
        {
            { "af", "Afrikaans" },
            { "sq", "Albanian" },
            { "am", "Amharic" },
            { "ar", "Arabic" },
            { "hy", "Armenian" },
            { "az", "Azerbaijani" },
            { "eu", "Basque" },
            { "be", "Belarusian" },
            { "bn", "Bengali" },
            { "bs", "Bosnian" },
            { "bg", "Bulgarian" },
            { "ca", "Catalan" },
            { "ceb", "Cebuano" },
            { "ny", "Chichewa" },
            { "zh-CN", "Chinese (Simplified)" },
            { "zh-TW", "Chinese (Traditional)" },
            { "co", "Corsican" },
            { "hr", "Croatian" },
            { "cs", "Czech" },
            { "da", "Danish" },
            { "nl", "Dutch" },
            { "en", "English"},
            { "eo", "Esperanto" },
            { "et", "Estonian" },
            { "tl", "Filipino" },
            { "fi", "Finnish" },
            { "fr", "French" },
            { "fy", "Frisian" },
            { "gl", "Galician" },
            { "ka", "Georgian" },
            { "de", "German" },
            { "el", "Greek"},
            { "gu", "Gujarati" },
            { "ht", "Haitian Creole" },
            { "ha", "Hausa" },
            { "haw", "Hawaiian" },
            { "he", "Hebrew" },
            { "iw", "Hebrew" },
            { "hi", "Hindi" },
            { "hmn", "Hmong" },
            { "hu", "Hungarian" },
            { "is", "Icelandic" },
            { "ig", "Igbo" },
            { "id", "Indonesian" },
            { "ga", "Irish" },
            { "it", "Italian" },
            { "ja", "Japanese" },
            { "jw", "Javanese" },
            { "kn", "Kannada" },
            { "kk", "Kazakh" },
            { "km", "Khmer" },
            { "rw", "Kinyarwanda" },
            { "ko", "Korean" },
            { "ku", "Kurdish (Kurmanji)" },
            { "ky", "Kyrgyz" },
            { "lo", "Lao" },
            { "la", "Latin" },
            { "lv", "Latvian" },
            { "lt", "Lithuanian" },
            { "lb", "Luxembourgish" },
            { "mk", "Macedonian" },
            { "mg", "Malagasy" },
            { "ms", "Malay" },
            { "ml", "Malayalam" },
            { "mt", "Maltese" },
            { "mi", "Maori" },
            { "mr", "Marathi" },
            { "mn", "Mongolian" },
            { "my", "Myanmar (Burmese)" },
            { "ne", "Nepali" },
            { "no", "Norwegian" },
            { "or", "Odia (Oriya)" },
            { "ps", "Pashto" },
            { "fa", "Persian" },
            { "pl", "Polish" },
            { "pt", "Portuguese" },
            { "pa", "Punjabi" },
            { "ro", "Romanian" },
            { "ru", "Russian" },
            { "sm", "Samoan" },
            { "gd", "Scots Gaelic" },
            { "sr", "Serbian" },
            { "st", "Sesotho" },
            { "sn", "Shona" },
            { "sd", "Sindhi" },
            { "si", "Sinhala" },
            { "sk", "Slovak" },
            { "sl", "Slovenian" },
            { "so", "Somali" },
            { "es", "Spanish" },
            { "su", "Sundanese" },
            { "sw", "Swahili" },
            { "sv", "Swedish" },
            { "tg", "Tajik" },
            { "ta", "Tamil" },
            { "tt", "Tatar" },
            { "te", "Telugu" },
            { "th", "Thai" },
            { "tr", "Turkish" },
            { "uk", "Ukrainian" },
            { "ur", "Urdu" },
            { "ug", "Uyghur" },
            { "uz", "Uzbek" },
            { "vi", "Vietnamese" },
            { "cy", "Welsh" },
            { "xh", "Xhosa" },
            { "yi", "Yiddish" },
            { "yo", "Yoruba" },
            { "zu", "Zulu" }
        };

        public Track() {}
        public Track(string key, string title, string subtitle, string background, string coverart, string genres, string text, string footer, string caption, string uri) {
            Key = key;
            Title = title;
            Subtitle = subtitle;
            Background = background;
            Coverart = coverart;
            Genres = genres;
            Text = text;
            Footer = footer;
            Caption = caption;
            Uri = uri;
        }        
    }
}
/*
{
    "key": "590804188",
    "title": "Like A Villain",
    "subtitle": "Bad Omens",
    "background": "https://is2-ssl.mzstatic.com/image/thumb/Music126/v4/fc/f8/08/fcf808aa-fc48-5b99-0734-f3eea9eb52a2/pr_source.png/800x800cc.jpg",
    "coverart": "https://is4-ssl.mzstatic.com/image/thumb/Music126/v4/03/49/0f/03490fc4-2ea2-61f3-6bbf-5382ea002087/810016765424.jpg/400x400cc.jpg",
    "genres": "Metal",
    "text": [
                "Look into my face, then look again",
                "We are not the same, we're different",
                "To tell your tales and fables, you couldn't wait",
                "You need a new clean slate without the dents",
                "A place to put your pain, your consequence",
                "When you look into the mirror, are you even there?",
                "",
                "I don't wanna know all your secrets 'cause I'll tell",
                "It's hard enough being alone with myself",
                "I don't know how long I'll be holding on",
                "I know you tried your hardest, I know that you meant well",
                "But you pushed me to the edge, and I slipped and then I fell",
                "I don't know how long I'll be holding on",
                "",
                "So write a brand new page, then write again",
                "I know your act is staged yet you pretend",
                "All while you're turning tables with missing legs",
                "I think you've overstayed your welcome in",
                "So go the fuck away, don't come again",
                "I'll see your face in the fire and burn it out",
                "",
                "I don't wanna know all your secrets 'cause I'll tell",
                "It's hard enough being alone with myself",
                "I don't know how long I'll be holding on",
                "I know you tried your hardest, I know that you meant well",
                "But you pushed me to the edge, and I slipped and then I fell",
                "I don't know how long I'll be holding on",
                "",
                "Like a villain, I couldn't be",
                "I didn't need it, it needed me",
                "Like a villain, I couldn't be",
                "I didn't need it, it needed me",
                "",
                "I didn't need it, it needed me",
                "",
                "I don't wanna know all your secrets 'cause I'll tell",
                "It's hard enough being alone with myself",
                "I don't know how long I'll be holding on",
                "I know you tried your hardest, I know that you meant well",
                "But you pushed me to the edge, and I slipped, and then I fell",
                "I don't know how long I'll be holding on",
                "",
                "I didn't need it, it needed me"
            ],
    "footer": "Writer(s): Joakim Oskar Patrick Karlsson, Noah Sebastian Davis\nLyrics powered by www.musixmatch.com",
    "caption": "BAD OMENS - Like A Villain (Official Music Video)",
    "url": "https://i.ytimg.com/vi/Aibxit_PpAg/maxresdefault.jpg",
    "uri": "https://youtu.be/Aibxit_PpAg?autoplay=1"
}
*/