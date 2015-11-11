using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public string  Account { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
