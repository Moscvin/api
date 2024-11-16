using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Models;
using api.Mappers;
using api.Dtos.Stock;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepo = stockRepository;
        }

        // Endpoint pentru a obține toate înregistrările Stock
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepo.GetAllSync();
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList(); // Convertire la DTO
            return Ok(stockDto);
        }

        // Endpoint pentru a obține o înregistrare Stock după ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDTO();
            var createdStock = await _stockRepo.CreateAsync(stockModel); // Numele metodei corectat
            return CreatedAtAction(nameof(GetById), new { id = createdStock.Id }, createdStock.ToStockDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedStock = await _stockRepo.UpdateAsync(id, updateDto); // Numele metodei corectat

            if (updatedStock == null)
            {
                return NotFound();
            }

            return Ok(updatedStock.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedStock = await _stockRepo.DeleteAsync(id); // Numele metodei corectat

            if (deletedStock == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
