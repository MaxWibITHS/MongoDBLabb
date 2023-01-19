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
        public void Delete(int Id)
        {
            var filter = Builders<ItemModel>.Filter.Eq("artnr", Id);
            var item = collection.Find(filter).FirstOrDefault();
            if(item != null)
            {
                collection.DeleteOne(filter);
                Console.WriteLine("Objekt borttaget.");
            }
            else
            {
                Console.WriteLine("Hittade inget objekt som matchade. Inget togs bort.");
                return;
            }
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
            var item = collection.Find(filter).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("Artikeln du ville uppdatera finns inte i listan");
                return;
            }
            var update = Builders<ItemModel>.Update.Set("qty", newid);
            
            collection.UpdateOne(filter, update);
            Console.WriteLine("Artikeln uppdaterad.");
        }
    }
}

