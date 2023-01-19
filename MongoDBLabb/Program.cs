// See https://aka.ms/new-console-template for more information
using MongoDB.Bson.Serialization.Attributes;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDBLabb;

IStrings io;
IDAO itemDao;
io = new TextIO();

itemDao = new DbDAO(File.ReadAllText($"ConnectionPass.txt"), "MinDB", "Items");
ItemController itemController = new ItemController(io, itemDao);
itemController.StartItemControl();
