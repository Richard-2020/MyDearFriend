using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

public class MongoDbService
{
    private readonly IMongoCollection<BsonDocument> _nameCollection;

    public MongoDbService()
    {
        var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
        var database = dbClient.GetDatabase("DearFriend");
        _nameCollection = database.GetCollection<BsonDocument>("AnonText");
    }

    public async Task<BsonDocument> GetDocumentByNameAsync(string name)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("name", name);
        return await _nameCollection.Find(filter).FirstOrDefaultAsync();
    }


}
