using MongoDB.Driver;
using UserAccount.Models;

namespace UserAccount.Database
{
    public interface IAccountContext
    {
        IMongoCollection<Account> Accounts { get; }
    }
}