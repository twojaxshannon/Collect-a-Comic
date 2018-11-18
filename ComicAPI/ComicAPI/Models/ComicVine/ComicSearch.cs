using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models.ComicVine
{
    public class ComicSearch
    {
        public ComicSearch()
        {

        }

        public VolumeFilter VolumeFilterCriteria { get; set; }
        public VolumeSort VolumeSortCriteria { get; set; }
        public IssueFilter IssueFilterCriteria { get; set; }
        public IssueSort IssueSortCriteria { get; set; }
    }
}
