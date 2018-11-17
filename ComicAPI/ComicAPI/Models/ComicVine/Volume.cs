namespace ComicAPI.Models.ComicVine
{
    public class Volume
    {
        public string Aliases { get; set; }
        public string Api_detail_url { get; set; }
        public int Count_of_issues { get; set; }
        public string Date_added { get; set; }
        public string Date_last_updated { get; set; }
        public string Deck { get; set; }
        public string Description { get; set; }
        public First_Issue First_issue { get; set; }
        public int Id { get; set; }
        public Image Image { get; set; }
        public Last_Issue Last_issue { get; set; }
        public string Name { get; set; }
        public Publisher Publisher { get; set; }
        public string Site_detail_url { get; set; }
        public string Start_year { get; set; }
    }

}