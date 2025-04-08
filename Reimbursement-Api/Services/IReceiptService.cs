using ReimbursementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReimbursementApi.Services
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> GetAllReceiptsAsync();
        Task<Receipt?> GetReceiptByIdAsync(int id);
        Task<Receipt> CreateReceiptAsync(Receipt receipt);
        Task<Receipt> UpdateReceiptAsync(Receipt receipt);
        Task<bool> DeleteReceiptAsync(int id);
    }
}
