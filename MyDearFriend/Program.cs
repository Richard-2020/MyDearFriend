using MongoDB.Bson;
using MongoDB.Driver;


// connection to Mongo db Database
var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
IMongoDatabase db = dbClient.GetDatabase("DearFriend");
var emp = db.GetCollection<BsonDocument>("AnonText");

var filter = Builders<BsonDocument>.Filter.Eq("name", "Richard Rangala");
var doc = emp.Find(filter).FirstOrDefault();
Console.WriteLine(doc.ToString());


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
