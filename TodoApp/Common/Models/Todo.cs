using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApp.Common.Models
{
    public class Todo
    {
        #region Properties

        [BsonId]
        public ObjectId IntenalId { get; set; }

        [BsonElement("Id")]
        public long Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        #endregion
    }
}
