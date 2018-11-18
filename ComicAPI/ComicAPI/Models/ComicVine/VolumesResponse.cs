namespace ComicAPI.Models.ComicVine
{
    /* Volumes */

    public class VolumesResponse
    {
        public string Error { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Number_of_page_results { get; set; }
        public int Number_of_total_results { get; set; }
        public int Status_code { get; set; }
        public Volume[] Results { get; set; }
        public string Version { get; set; }
    }

}