using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Stock>> GetAllSync()
        {
            return _context.Stocks.ToListAsync();
        }
        public Task<Stock> GetById(int id)
        {
            return _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Stock> Create(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
        public async Task<Stock> Update(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
        public async Task<Stock> Delete(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
    }
}
}