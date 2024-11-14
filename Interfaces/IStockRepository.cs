using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllSync();
        Task<Stock?> GetByIdAsync(int id); // Numele corectat pentru a se potrivi cu controller-ul
        Task<Stock> CreateAsync(Stock stockModel); // Numele corectat pentru a se potrivi cu controller-ul
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto); // Numele corectat
        Task<Stock?> DeleteAsync(int id); // Numele corectat
    }
}