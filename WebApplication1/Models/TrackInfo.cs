using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models {
    public class TrackInfo {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Images Images { get; set; }
        public string Url { get; set; }
        public Genres Genres { get; set; }
        public List<Section> Sections { get; set; }
    }

    public class Images {
        public string Background { get; set; }
        public string Coverart { get; set; }
    }

    public class Genres {
        public string Primary { get; set; }
    }

    public class Section {
        public string Type { get; set; }
        public List<string> Text { get; set; }
        public string Footer { get; set; }
        public Youtubeurl Youtubeurl { get; set; }
    }

    public class Youtubeurl {
        public string Caption { get; set; }
        public Image Image { get; set; }
        public List<Action> Actions { get; set; }
    }

    public class Image {
        public Dimensions Dimensions { get; set; }
        public string Url { get; set; }
    }

    public class Action {
        public string Uri { get; set; }
    }

    public class Dimensions {
        public int Width { get; set; }
        public int Height { get; set; }
    }   
}
/*
{
    "type": "MUSIC",
    "key": "590804188",
    "title": "Like A Villain",
    "subtitle": "Bad Omens",
    "images": {
        "background": "https://is2-ssl.mzstatic.com/image/thumb/Music126/v4/fc/f8/08/fcf808aa-fc48-5b99-0734-f3eea9eb52a2/pr_source.png/800x800cc.jpg",
        "coverart": "https://is4-ssl.mzstatic.com/image/thumb/Music126/v4/03/49/0f/03490fc4-2ea2-61f3-6bbf-5382ea002087/810016765424.jpg/400x400cc.jpg",
    },
    "url": "https://www.shazam.com/track/590804188/like-a-villain",
    "genres": {
        "primary": "Metal"
    },
    "sections": [
        {
            "type": "LYRICS",
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
            "footer": "Writer(s): Joakim Oskar Patrick Karlsson, Noah Sebastian Davis\nLyrics powered by www.musixmatch.com"
        },
        {
            "type": "VIDEO",
            "youtubeurl": {
                "caption": "BAD OMENS - Like A Villain (Official Music Video)",
                "image": {
                    "dimensions": {
                        "width": 1280,
                        "height": 720
                    },
                    "url": "https://i.ytimg.com/vi/Aibxit_PpAg/maxresdefault.jpg"
                },
                "actions": [
                    {
                        "uri": "https://youtu.be/Aibxit_PpAg?autoplay=1"
                    }
                ]
            }
        }
    ]
}
*/