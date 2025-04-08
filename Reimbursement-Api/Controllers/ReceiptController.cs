using Microsoft.AspNetCore.Mvc;
using ReimbursementApi.Models;
using ReimbursementApi.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ReimbursementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;
        private readonly string _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;

            if (!Directory.Exists(_uploadsFolder))
                Directory.CreateDirectory(_uploadsFolder);
        }

        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public async Task<IActionResult> SubmitReceipt([FromForm] ReceiptFormModel form)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? filePath = null;

            if (form.ReceiptFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(form.ReceiptFile.FileName);
                filePath = Path.Combine("Uploads", fileName);
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                using var stream = new FileStream(fullPath, FileMode.Create);
                await form.ReceiptFile.CopyToAsync(stream);
            }

            var receipt = new Receipt
            {
                PurchaseDate = form.PurchaseDate,
                Amount = form.Amount,
                Description = form.Description,
                ReceiptFilePath = filePath
            };

            var created = await _receiptService.CreateReceiptAsync(receipt);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var receipts = await _receiptService.GetAllReceiptsAsync();
            return Ok(receipts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receipt = await _receiptService.GetReceiptByIdAsync(id);
            if (receipt == null)
                return NotFound();
            return Ok(receipt);
        }
    }
}
