using MongoDB.Driver;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public interface IAccountContext
    {
        IMongoCollection<Account> Accounts { get; }
    }
}