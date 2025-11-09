using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Dto;
using clientsApi.Dto.CommentDto;

namespace clientsApi.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Models.Comment>> GetAllAsync();
        Task<Models.Comment?> GetByIdAsync(int id);
        Task<Models.Comment> CreateAsync(Models.Comment commentModel);
        Task<Models.Comment?> UpdateAsync(int id, UpdateCommentDto updateCommentDto); //FirstOrDefault CAN BE NULL
        Task<Models.Comment?> DeleteAsync(int id);
    }
}