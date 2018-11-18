using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models.ComicVine
{
    public class VolumeSort
    {
        public VolumeSort()
        {
            Name = "Asc";
        }

        public string Date_added { get; set; }
        public string Date_last_updated { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
