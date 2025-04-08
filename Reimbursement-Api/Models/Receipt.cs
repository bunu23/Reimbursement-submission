using System;
using System.ComponentModel.DataAnnotations;

namespace ReimbursementApi.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ReceiptFilePath { get; set; }
    }
}
