using ReimbursementApi.Models;
using ReimbursementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReimbursementApi.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync()
        {
            return await _receiptRepository.GetAllAsync();
        }

        public async Task<Receipt?> GetReceiptByIdAsync(int id)
        {
            return await _receiptRepository.GetByIdAsync(id);
        }

        public async Task<Receipt> CreateReceiptAsync(Receipt receipt)
        {
            return await _receiptRepository.AddAsync(receipt);
        }

        public async Task<Receipt> UpdateReceiptAsync(Receipt receipt)
        {
            return await _receiptRepository.UpdateAsync(receipt);
        }

        public async Task<bool> DeleteReceiptAsync(int id)
        {
            return await _receiptRepository.DeleteAsync(id);
        }
    }
}
