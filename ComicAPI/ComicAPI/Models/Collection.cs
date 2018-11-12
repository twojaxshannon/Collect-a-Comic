using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CollectedVolume> CollectedVolumes { get; set; }
    }
}
