using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models {
    public class Shazam {
        public Tracks Tracks { get; set; }       
    }

    public class Tracks {
        public List<Hit> Hits { get; set; }
    }

    public class Hit {
        public NewTrack Track { get; set; }
    }

    public class Share {
        public string Subject { get; set; }
        public string Href { get; set; }
        public string Image { get; set; }
        public string Avatar { get; set; }
    }

    public class NewTrack {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }

        [Display(Name = "Artist")]
        public string Subtitle { get; set; }
        public Share Share { get; set; }
    }
}
/*
 {
    "tracks": {
        "hits": [
            {
                "track": {
                    "type": "MUSIC",
                    "key": "590804188",
                    "title": "Like A Villain",
                    "subtitle": "Bad Omens",
                    "share": {
                        "subject": "Like A Villain - Bad Omens",
                        "href": "https://www.shazam.com/track/590804188/like-a-villain",
                        "image": "https://is4-ssl.mzstatic.com/image/thumb/Music126/v4/03/49/0f/03490fc4-2ea2-61f3-6bbf-5382ea002087/810016765424.jpg/400x400cc.jpg",
                        "avatar": "https://is2-ssl.mzstatic.com/image/thumb/Music126/v4/fc/f8/08/fcf808aa-fc48-5b99-0734-f3eea9eb52a2/pr_source.png/800x800cc.jpg",
                    }                                                          
                }
            }
        ]
    }
}
 */