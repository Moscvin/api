using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllSync();
        Task<Stock> GetById(int id);
        Task<Stock> Create(Stock stock);
        Task<Stock> Update(Stock stock);

        Task<Stock> Delete(int id);
    }
}