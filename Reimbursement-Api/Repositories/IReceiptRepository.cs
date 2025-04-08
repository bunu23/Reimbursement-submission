using System.Collections.Generic;
using System.Threading.Tasks;
using ReimbursementApi.Models;

namespace ReimbursementApi.Repositories
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllAsync();
        Task<Receipt> GetByIdAsync(int id);
        Task<Receipt> AddAsync(Receipt receipt);
        Task<bool> DeleteAsync(int id);
        Task<Receipt> UpdateAsync(Receipt receipt);
    }
}
