using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using MyDearFriend;
using MyDearFriend.Pages;


public class IndexModel
{
    private readonly ILogger<IndexModel> _logger;

   

    private readonly Database _database;

    public IndexModel()
    {
        var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
        IMongoDatabase db = dbClient.GetDatabase("DearFriend");
        var emp = db.GetCollection<MessageModel>("Message");



        //var message = new MessageModel { message = "Hello guyssss", Timestamp = DateTime.Now };
        //emp.InsertOneAsync(message);

        var results = emp.FindAsync(_ => true);
        

        foreach (var result in results.ToList())
        {
            Console.WriteLine($"{result.Id}: {result.message}");
        }
    }

    //public IndexModel(Database database)
    //{
    //    _database = database;
    //}

    public List<BsonDocument> Documents { get; private set; } = new List<BsonDocument>();

    public async Task OnGetAsync()
    {
        Documents = await _database.GetAllDocumentsAsync();
    }

    public void OnGet()
    {

    }

        
}

