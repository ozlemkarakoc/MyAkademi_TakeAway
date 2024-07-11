using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyAkademi_TakeAway.Catalog.Entities
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
