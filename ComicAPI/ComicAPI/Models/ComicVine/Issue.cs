namespace ComicAPI.Models.ComicVine
{
    public class Issue
    {
        public object Aliases { get; set; }
        public string Api_detail_url { get; set; }
        public string Cover_date { get; set; }
        public string Date_added { get; set; }
        public string Date_last_updated { get; set; }
        public object Deck { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public Image Image { get; set; }
        public string Issue_number { get; set; }
        public string Name { get; set; }
        public string Site_detail_url { get; set; }
        public string Store_date { get; set; }
        public VolumeSnippet Volume { get; set; }
    }

}