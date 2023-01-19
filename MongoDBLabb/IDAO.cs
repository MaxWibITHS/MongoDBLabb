using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBLabb
{
    internal interface IDAO
    {
        public void Create(ItemModel item);
        public void Update(int id, int newid);
        public void Delete(int id);
        List<ItemModel> ReadAll();
        public ItemModel ReadOne(int id);
    }
}



