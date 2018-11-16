using ComicAPI.Models.Abstract;
using ComicAPI.Models.ComicVine;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComicAPI.Models
{
    public class CollectedVolume : IBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public Volume VolumeInfo { get; set; }
        
        public List<Issue> CollectedIssues { get; set; }
    }
}
