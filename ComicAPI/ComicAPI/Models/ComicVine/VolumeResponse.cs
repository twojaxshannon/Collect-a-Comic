using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models.ComicVine
{
    public class VolumeResponse
    {
        public string Error { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Number_of_page_results { get; set; }
        public int Number_of_total_results { get; set; }
        public int Status_code { get; set; }
        public Volume Results { get; set; }
        public string Version { get; set; }

        // TODO: See if there's a clean way to merge thsi back into the multi-volume response, maybe by modifying setter on Results.
    }
}