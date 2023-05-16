using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class HexaMemberDto { 
     public string Id { get; set; }
        public string name { get; set; } 
        public int age { get; set; } 
        public double address { get; set; } 
        public int phone { get; set; } 
        public int project { get; set; } 
        public DateTime aa { get; set; } 
        public bool bb { get; set; } 
        public int cc { get; set; } 
} 
}
