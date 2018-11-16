using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Models.Abstract
{
    public interface IBaseModel
    {
        ObjectId Id { get; set; }
    }
}
