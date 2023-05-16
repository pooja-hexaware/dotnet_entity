using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class HexaMember
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string name  { get; set; }
        public int age  { get; set; }
        public double address  { get; set; }
        public int phone  { get; set; }
        public int project  { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime aa  { get; set; }
        public bool bb  { get; set; }
        public int cc  { get; set; }
        
    }

}