using ComicAPI.Models.ComicVine;
using System.Collections.Generic;

namespace ComicAPI.Models
{
    public class CollectedVolume
    {
        public int Id { get; set; }
        public Volume VolumeInfo { get; set; }
        public List<Issue> CollectedIssues { get; set; }
    }
}
