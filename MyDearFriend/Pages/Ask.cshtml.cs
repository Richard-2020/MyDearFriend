using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace MyDearFriend.Pages
{
    public class AskModel : PageModel
    {
        public string connection = "mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/";
        public string databaseName = "DearFriend";
        public string collectionName = "Message";

        //public static MongoClient dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
        //public static IMongoDatabase db = dbClient.GetDatabase("DearFriend");
        //public static Collection = db.GetCollection<MessageModel>("Message");
        //public MessageModel message = new MessageModel { message = "Hello guys again", Timestamp = DateTime.Now };

        
        




        public bool hasData = false;
        public string msg = "";
        public bool hasDisplay = false;
        private readonly IMongoCollection<Message> _messagesCollection;

        
        public string MessageContent { get; set; }
        
        Message message = new Message
        {
            Content = "Your message content",
            Timestamp = DateTime.Now
        };

        

        public class Message
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("Content")]
            public string Content { get; set; }
            public DateTime Timestamp { get; set; }
        }



        public void OnGet()
        {

        }

        



        public void OnPost()
        {
            
            hasData = true;
            msg = Request.Form["msg"];

            void method()
            {
                var dbClient = new MongoClient("mongodb+srv://richardrangs:VXj0Z32cjBrKsFZl@cluster0.r5ip8.mongodb.net/");
                IMongoDatabase db = dbClient.GetDatabase("DearFriend");
                var emp = db.GetCollection<MessageModel>("Message");
                var message = new MessageModel { message = msg, Timestamp = DateTime.Now };
                emp.InsertOne(message);
            }
            method();
        }
    }
}
