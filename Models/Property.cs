using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAppParser.Models
{
    public class Property
    {
        public static Dictionary<string, string> propertyD = new Dictionary<string, string>();

        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("URL")]
        public string Url { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Prize")]
        public string Prize { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Area")]
        public string Area { get; set; }

        [BsonElement("Rooms")]
        public string Rooms { get; set; }

        [BsonElement("Floor")]
        public string Floor { get; set; }

        [BsonElement("Furnitured")]
        public string Furnitured { get; set; }

        [BsonElement("Development")]
        public string Development { get; set; }

        [BsonElement("PrizePerM")]
        public string PrizePerM { get; set; }

        [BsonElement("OfferFrom")]
        public string OfferFrom { get; set; }

        [BsonElement("Trade")]
        public string Trade { get; set; }

        [BsonElement("Fee")]
        public string Fee { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Parking")]
        public string Parking { get; set; }

        [BsonElement("Bathrooms")]
        public string Bathrooms { get; set; }

        [BsonElement("Heating")]
        public string Heating { get; set; }

        [BsonElement("Floors")]
        public string Floors { get; set; }

        [BsonElement("ImageString")]
        public List<String> Image { get; set; }

        [BsonElement("ImageIds")]
        public List<ObjectId> ImageIds { get; set; }
    }
}
