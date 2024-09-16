using MongoDB.Bson;
using MongoDB.Driver;
using MyDearFriend.Pages;




// connection to Mongo db Database
var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
IMongoDatabase db = dbClient.GetDatabase("DearFriend");
var emp = db.GetCollection<MessageModel>("Message");



var message = new MessageModel { message = "Hello guys", Timestamp = DateTime.Now };
await emp.InsertOneAsync(message);

var results = await emp.FindAsync(_ => true);


foreach (var result in results.ToList())
{
    Console.WriteLine($"{result.Id}: {result.message}");
}




//var filter = Builders<BsonDocument>.Filter.Eq("name", "Richard Rangala");
//var doc = emp.Find(filter).FirstOrDefault();
//Console.WriteLine(doc.ToString());


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
