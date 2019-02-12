using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserAccount.Config;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public class AccountContext : IAccountContext
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Account");

        public AccountContext(IOptions<DatabaseConfig> config)
        {
            if (config?.Value == null)
                throw new ArgumentNullException(nameof(config));

            var client = new MongoClient(config.Value.ConnectionString);

            if (client != null)
            {
                _database = client.GetDatabase(config.Value.DatabaseName);
            }
        }
    }
}