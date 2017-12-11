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
            #if DEBUG
            var url = MongoUrl.Create(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            #else
            var url = MongoUrl.Create(ConfigurationManager.AppSettings.Get("MONGOLAB_URI"));
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
            var mixes = _collection.Find(FilterDefinition<Mix>.Empty).Limit(20).ToList();
            return mixes;
        }

        public IEnumerable<Mix> GetMixes(MixSearchFilter _filter)
        {
            List<FilterDefinition<Mix>> filters = new List<FilterDefinition<Mix>>();
            var builder = Builders<Mix>.Filter;

            if (_filter.MixName != string.Empty)
                filters.Add(builder.Eq("MixName", _filter.MixName));
            if (_filter.RatioHigh != null)
                filters.Add(builder.Lte("CFx", _filter.CFxHigh));
            if (_filter.RatioLow != null)
                filters.Add(builder.Gte("CFx", _filter.CFxLow));
            if (_filter.RatioHigh != null)
                filters.Add(builder.Lte("SVO", _filter.SVOHigh));
            if (_filter.RatioLow != null)
                filters.Add(builder.Gte("SVO", _filter.SVOLow));
            if (_filter.RatioHigh != null)
                filters.Add(builder.Lte("Carbon", _filter.CarbonHigh));
            if (_filter.RatioLow != null)
                filters.Add(builder.Gte("Carbon", _filter.CarbonLow));
            if (_filter.RatioHigh != null)
                filters.Add(builder.Lte("Binder", _filter.BinderHigh));
            if (_filter.RatioLow != null)
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

        public void Search(MixSearchFilter filter)
        {
            throw new NotImplementedException();
        }
        public void AddPellet(Pellet pellet)
        {
            throw new NotImplementedException();
        }

    }
}