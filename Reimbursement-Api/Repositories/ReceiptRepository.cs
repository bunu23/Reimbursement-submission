using Microsoft.EntityFrameworkCore;
using ReimbursementApi.Data;
using ReimbursementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReimbursementApi.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppDbContext _context;

        public ReceiptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            try
            {
                return await _context.Receipts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _context.Receipts.FindAsync(id);
        }

        public async Task<Receipt> AddAsync(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
                return false;

            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Receipt> UpdateAsync(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }
    }
}