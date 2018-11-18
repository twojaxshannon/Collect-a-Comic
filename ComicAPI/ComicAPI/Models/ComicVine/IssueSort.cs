using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models.ComicVine
{
    public class IssueSort
    {

        public IssueSort()
        {
            Issue_number = "Desc";
        }
        
        public string Cover_date { get; set; }
        public string Date_added { get; set; }
        public string Date_last_updated { get; set; }
        public string Id { get; set; }
        public string Issue_number { get; set; }
        public string Store_date { get; set; }
        public string Name { get; set; }
    }
}
