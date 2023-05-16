using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Repositories
{
    public class HexaMemberRepository : IHexaMemberRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "HexaMember";

        public HexaMemberRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<HexaMember> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<HexaMember>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public HexaMember Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<HexaMember>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(HexaMember entity)
        {
            _gateway.GetMongoDB().GetCollection<HexaMember>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public HexaMember Update(string id, HexaMember entity)
        {
            var update = Builders<HexaMember>.Update
                .Set(e => e.name, entity.name )
                .Set(e => e.age, entity.age )
                .Set(e => e.address, entity.address )
                .Set(e => e.phone, entity.phone )
                .Set(e => e.project, entity.project )
                .Set(e => e.aa, entity.aa )
                .Set(e => e.bb, entity.bb )
                .Set(e => e.cc, entity.cc );

            var result = _gateway.GetMongoDB().GetCollection<HexaMember>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<HexaMember>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
