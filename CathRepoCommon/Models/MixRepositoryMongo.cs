using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CathRepoCommon.Models;
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
            var url = MongoUrl.Create(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            _client = new MongoClient(url);
            _database = _client.GetDatabase("mixes");
            _collection = _database.GetCollection<Mix>("Mix");
        }

        public void AddMix(Mix mix)
        {
            _collection.InsertOne(mix);
        }

        public void AddMix(IEnumerable<Mix> mixes)
        {
            _collection.InsertMany(mixes);
        }

        public void DeleteMix(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mix> GetMixes()
        {
            //FilterDefinition<Mix> mixFilter = new FilterDefinition<Mix>();
            var mixes = _collection.Find(FilterDefinition<Mix>.Empty).Limit(10).ToList();
            return mixes;
        }

        public void UpdateDetails(Mix mix)
        {
            throw new NotImplementedException();
        }

        public void AddPellet(Pellet pellet)
        {
            throw new NotImplementedException();
        }
    }
}