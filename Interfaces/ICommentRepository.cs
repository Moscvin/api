using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllSync();

        Task<Comment?> GetByIdSync(int id);

        Task<Comment> CreateAsync(Comment commentModel);


    }
}