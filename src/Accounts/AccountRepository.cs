using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(Account account)
        {
            account.Id = Guid.NewGuid().ToString();

            await _context.Accounts.InsertOneAsync(account);

            return account.Id;
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Accounts.DeleteOneAsync(a => a.Id == id);
        }

        public async Task<Account> GetAsync(string id)
        {
            return await _context.Accounts.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Account account)
        {
            account.Id = id;

            await _context.Accounts.ReplaceOneAsync(
                a => a.Id == id, 
                account, 
                new UpdateOptions{ IsUpsert = true });
        }
    }
}