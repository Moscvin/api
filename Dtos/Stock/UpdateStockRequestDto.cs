using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Symbol must be at least 1 character long")]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters long")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Company Name must be at least 1 character long")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000, ErrorMessage = "Purchase must be at least 1")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100, ErrorMessage = "Last Div must be at least 0")]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Industry must be at least 1 character long")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000, ErrorMessage = "Market Cap must be at least 1")]
        public long MarketCap { get; set; }
    }
}