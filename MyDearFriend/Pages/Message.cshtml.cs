using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDearFriend.Pages
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string message { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
