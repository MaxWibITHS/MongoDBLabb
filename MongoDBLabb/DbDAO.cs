using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBLabb;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace MongoDBLabb
{
    internal class DbDAO : IDAO
    {
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<ItemModel> collection;
        public DbDAO(string pass, string database, string collection)
        {
            dbClient = new MongoClient(pass);
            this.database = this.dbClient.GetDatabase(database);
            this.collection = this.database.GetCollection<ItemModel>(collection);
        }
        public void Create(ItemModel item)
        {
            collection.InsertOne(item);  
        }
        public void Delete(int id)
        {
            var filter = Builders<ItemModel>.Filter.Eq("artnr", id);
            collection.DeleteOne(filter);
        }
        public List<ItemModel> ReadAll()
        {
            return collection.Find(new BsonDocument()).ToList();      
        }
        public ItemModel ReadOne(int id)
        {
            var filter = Builders<ItemModel>.Filter.Eq("artnr", id);
            var item = collection.Find(filter).FirstOrDefault();
            return item;
        }
        public void Update(int id, int newid)
        {
            var filter = Builders<ItemModel>.Filter.Eq("artnr", id);
                  
            var update = Builders<ItemModel>.Update.Set("qty", newid);
            collection.UpdateOne(filter, update);   
        }
    }
}

