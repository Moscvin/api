using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.Models;
using api.Dtos.Stock;


namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Endpoint pentru a obține toate înregistrările Stock
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
            .Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        // Endpoint pentru a obține o înregistrare Stock după ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        // public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        // {
        //     var stockModel = stockDto.ToStockFromCreateDTO();
        //     _context.Stocks.Add(stockModel);
        //     _context.SaveChanges();
        //     return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        // }

        // Metoda asincrona
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        

        [HttpPut("{id}")]

        // public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        // {
        //     var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

        //     if (stockModel == null)
        //     {
        //         return NotFound();
        //     }
        //     stockModel.Symbol = updateDto.Symbol;
        //     stockModel.CompanyName = updateDto.CompanyName;
        //     stockModel.Purchase = updateDto.Purchase;
        //     stockModel.LastDiv = updateDto.LastDiv;
        //     stockModel.Industry = updateDto.Industry;
        //     stockModel.MarketCap = updateDto.MarketCap;

        //     _context.SaveChanges();

        //     return Ok(stockModel.ToStockDto());
        // }
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _context.Stocks.FindAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }
    }
}
