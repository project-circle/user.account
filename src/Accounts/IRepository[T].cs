using System.Threading.Tasks;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(string id);

        Task<string> AddAsync(T account);

        Task UpdateAsync(string id, T account);

        Task DeleteAsync(string id);
    }
}