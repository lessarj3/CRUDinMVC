using CathRepoCommon.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathRepoCommon.Models
{
    public class MixRepositoryMongo : IMixRepository
    {

        private readonly IMongoCollection<Mix> _collection;
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public MixRepositoryMongo()
        {
            var databaseName = "mixes";
#if DEBUG
            var url = MongoUrl.Create(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
#else
            var url = MongoUrl.Create(ConfigurationManager.AppSettings.Get("MONGOLAB_URI"));
            databaseName = url.DatabaseName;
#endif
            _client = new MongoClient(url);
            _database = _client.GetDatabase(databaseName);
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
            var mixes = _collection.Find(FilterDefinition<Mix>.Empty).Limit(20).ToList();
            return mixes;
        }

        public IEnumerable<Mix> GetMixes(MixSearchFilter _filter)
        {
            List<FilterDefinition<Mix>> filters = new List<FilterDefinition<Mix>>();
            var builder = Builders<Mix>.Filter;

            if (_filter.MixName != null)
                filters.Add(builder.Regex("MixName", new BsonRegularExpression(".*" + _filter.MixName + ".*")));
            if (_filter.CFxHigh != null)
                filters.Add(builder.Lte("CFx", _filter.CFxHigh));
            if (_filter.CFxLow != null)
                filters.Add(builder.Gte("CFx", _filter.CFxLow));
            if (_filter.SVOHigh != null)
                filters.Add(builder.Lte("SVO", _filter.SVOHigh));
            if (_filter.SVOLow != null)
                filters.Add(builder.Gte("SVO", _filter.SVOLow));
            if (_filter.CarbonHigh != null)
                filters.Add(builder.Lte("Carbon", _filter.CarbonHigh));
            if (_filter.CarbonLow != null)
                filters.Add(builder.Gte("Carbon", _filter.CarbonLow));
            if (_filter.BinderHigh != null)
                filters.Add(builder.Lte("Binder", _filter.BinderHigh));
            if (_filter.BinderLow != null)
                filters.Add(builder.Gte("Binder", _filter.BinderLow));
            if (_filter.RatioHigh != null)
                filters.Add(builder.Lte("Ratio", _filter.RatioHigh));
            if (_filter.RatioLow != null)
                filters.Add(builder.Gte("Ratio", _filter.RatioLow));

            var filterList = builder.And(filters);
            var mixes = _collection.Find(filterList).Limit(10).ToList();
            return mixes;
        }

        public void UpdateDetails(Mix mix)
        {
            var filter = Builders<Mix>.Filter.Eq("_id", mix.Id);
            _collection.ReplaceOne(filter, mix);
        }

        public void UpdatePellets(string mixId, IEnumerable<Pellet> pellets)
        {
            var filter = Builders<Mix>.Filter.Eq("_id", mixId);
            var update = Builders<Mix>.Update.Set("Pellets", pellets);
            _collection.UpdateOne(filter, update);
        }
    }
}