using ComicAPI.Models.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models
{
    public class ComicCollection : IBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int UserId { get; set; }
        public List<CollectedVolume> CollectedVolumes { get; set; }
    }
}
