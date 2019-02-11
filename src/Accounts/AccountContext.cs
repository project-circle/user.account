using MongoDB.Driver;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public class AccountContext
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Account");

        public AccountContext(string connectionString)
        {
            var client = new MongoClient(connectionString);

            if (client != null)
            {
                _database = client.GetDatabase("Accounts");
            }
        }
    }
}