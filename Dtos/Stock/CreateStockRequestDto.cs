using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 5 characters long")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Company Name must be at most 50 characters long")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000, ErrorMessage = "Purchase must be at least 1")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100, ErrorMessage = "Last Div must be at least 0")]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Industry must be at most 50 characters long")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000, ErrorMessage = "Market Cap must be at least 1")]
        public long MarketCap { get; set; }
    }
}