// Program.cs
using MongoDB.Bson;
using MongoDB.Driver;
using MyDearFriend.Pages;

namespace MyDearFriend
{
    public class Database
    {
        public string connection = "mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/";
        public string databaseName = "DearFriend";
        public string collectionName = "Message";

        private readonly IMongoCollection<BsonDocument> emp;
        static void Main(string[] args)
        {
            // Your main met    hod logic
        }

        public Database()
        {
            var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
            IMongoDatabase db = dbClient.GetDatabase("DearFriend");
            var emp = db.GetCollection<BsonDocument>("Message");
        }

        public async Task<List<BsonDocument>> GetAllDocumentsAsync()
        {
            return await emp.Find(new BsonDocument()).ToListAsync();
        }
    }
}



//public class MongoDbService
//{
//    private readonly IMongoCollection<BsonDocument> _nameCollection;

//    public MongoDbService()
//    {
//        var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
//        var database = dbClient.GetDatabase("DearFriend");
//        _nameCollection = database.GetCollection<BsonDocument>("AnonText");
//    }

//    public async Task<BsonDocument> GetDocumentByNameAsync(string name)
//    {
//        var filter = Builders<BsonDocument>.Filter.Eq("name", name);
//        return await _nameCollection.Find(filter).FirstOrDefaultAsync();
//    }


//}
