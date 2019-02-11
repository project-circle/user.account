using MongoDB.Bson.Serialization.Attributes;

namespace UserAccount.Models
{
    public class Account
    {
        [BsonId]
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}