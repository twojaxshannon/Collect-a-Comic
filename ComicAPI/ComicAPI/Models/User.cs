﻿using ComicAPI.Models.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models
{
    public class User : IBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

    }
}
