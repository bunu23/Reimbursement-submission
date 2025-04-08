using System;
using System.ComponentModel.DataAnnotations;

namespace ReimbursementApi.Models
{
    public class ReceiptFormModel
    {
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile? ReceiptFile { get; set; }
    }
}