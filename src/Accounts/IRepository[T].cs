using System.Threading.Tasks;
using UserAccount.Models;

namespace UserAccount.Accounts
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(string id);

        Task<string> AddAsync(T entity);

        Task UpdateAsync(string id, T entity);

        Task DeleteAsync(string id);
    }
}