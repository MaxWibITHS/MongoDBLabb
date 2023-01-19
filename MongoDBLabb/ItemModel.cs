using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBLabb
{
    [BsonIgnoreExtraElements]
    
    public class ItemModel
    {
        [BsonId]
        
        public ObjectId BsonID { get; set; }

        [BsonElement("artnr")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("unit")]
        public string Unit { get; set; }
        [BsonElement("qty")]
        public int Qty { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        
    }
}



