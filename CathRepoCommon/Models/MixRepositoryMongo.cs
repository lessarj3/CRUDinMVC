using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CathRepoCommon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CathRepoCommon.Models
{
    public class MixRepositoryMongo : IMixRepository
    {

        private readonly IMongoCollection<Mix> _collection;
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public MixRepositoryMongo()
        {
            #if DEBUG
            var url = MongoUrl.Create(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            #else
            var url = MongoUrl.Create(ConfigurationManager.AppSettings.Get("(MONGOHQ_URL|MONGOLAB_URI)"));
            #endif




            _client = new MongoClient(url);
            _database = _client.GetDatabase("mixes");
            _collection = _database.GetCollection<Mix>("Mix");
        }

        public void AddMix(Mix mix)
        {
            mix.Id = Guid.NewGuid().ToString();
            _collection.InsertOne(mix);
        }

        public void AddMix(IEnumerable<Mix> mixes)
        {
            _collection.InsertMany(mixes);
        }

        public void DeleteMix(string id)
        {
            var filter = Builders<Mix>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public IEnumerable<Mix> GetMixes()
        {
            //List<FilterDefinition<Mix>> filters = new List<FilterDefinition<Mix>>();
            //var builder = Builders<Mix>.Filter;
            //filters.Add(builder.Lte(key, valueB));
            //filters.Add(builder.Gte("MixName", string.Empty));
            //var filter = builder.And(filters);
            //var mixes = _collection.Find(filter).Limit(10).ToList();

            var mixes = _collection.Find(FilterDefinition<Mix>.Empty).Limit(10).ToList();
            return mixes;
        }

        public void UpdateDetails(Mix mix)
        {
            var filter = Builders<Mix>.Filter.Eq("_id", mix.Id);
            _collection.ReplaceOne(filter, mix);
        }

        
    }
}