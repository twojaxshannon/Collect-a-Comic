using ComicAPI.DAL.Utility;
using ComicAPI.Models.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.DAL.Abstract
{
    public abstract class BaseRepository<TModel>
        where TModel : IBaseModel
    {
        private readonly DALConfig dbConfig;
        private readonly IMongoDatabase mongoDatabase;
        protected readonly IMongoCollection<TModel> mongoCollection;

        #region Constructors
        /// <summary>
        /// Initialize the repository with default configurations.
        /// </summary>
        public BaseRepository()
        {
            dbConfig = new DALConfig();
            mongoDatabase = dbConfig.GetMongoDatabase();
            mongoCollection = mongoDatabase.GetCollection<TModel>(typeof(TModel).Name);
        }

        /// <summary>
        /// Initialize the repository with custom configurations.
        /// </summary>
        /// <param name="config">Custom data access configurations</param>
        public BaseRepository(DALConfig config)
        {
            dbConfig = config;
            mongoDatabase = dbConfig.GetMongoDatabase();
            mongoCollection = mongoDatabase.GetCollection<TModel>(typeof(TModel).Name);
        }
        #endregion

        #region Edit Data
        /// <summary>
        /// Update the given document in the collection, or add it if it does not exist.
        /// </summary>
        /// <param name="model">Model information / mongo document to be saved</param>
        public void Save(TModel model)
        {
            if (model.Id != BsonObjectId.Empty)
            {
                // The model exists, so update it.
                Update(model);
            }
            else
            {
                // The model does not exist, so add it.
                Add(model);
            }
        }

        /// <summary>
        /// Delete the given document from the collection.
        /// </summary>
        /// <param name="model">Document to delete</param>
        public void Delete(TModel model)
        {
            mongoCollection.DeleteOne(x => x.Id == model.Id);
        }

        /// <summary>
        /// Insert the given document into the collection.
        /// </summary>
        /// <param name="model">Document to add</param>
        private void Add(TModel model)
        {
            mongoCollection.InsertOne(model);
        }

        /// <summary>
        /// Update the given document by its ID value.
        /// </summary>
        /// <param name="model">Document to update</param>
        private void Update(TModel model)
        {
            mongoCollection.ReplaceOne(x => x.Id == model.Id, model);
        }
        #endregion

        #region Retrieve Data
        /// <summary>
        /// Retrieve the first document with the given Id value.
        /// </summary>
        /// <param name="id">Unique document identifier</param>
        /// <returns>The first instance of TModel</returns>
        public TModel Get(ObjectId id)
        {
            return mongoCollection.Find<TModel>(x => x.Id == id).First();
        }

        /// <summary>
        /// Retrieve a list of all documents in the collection.
        /// </summary>
        /// <returns>All instances of TModel found within the collection</returns>
        public List<TModel> GetAll()
        {
            return mongoCollection.Find(FilterDefinition<TModel>.Empty).ToList();
        }
        #endregion
    }
}
