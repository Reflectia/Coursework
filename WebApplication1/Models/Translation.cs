namespace WebApplication1.Models {
    public class Translation {
        public Data data { get; set; }   
    }

    public class Data {
        public string translation { get; set; }
        public List<Pair> pairs { get; set; }
    }

    public class Pair {
        public string s { get; set; }
        public string t { get; set; }
    }
}
