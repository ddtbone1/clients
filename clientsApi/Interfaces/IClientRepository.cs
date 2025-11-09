using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Dto;
using clientsApi.Helpers;

namespace clientsApi.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Models.Client>> GetAllAsync(QueryObject query);
        Task<Models.Client?> GetByIdAsync(int id); //FirstOrDefault CAN BE NULL
        Task<Models.Client> CreateAsync(Models.Client clientModel);
        Task<Models.Client?> UpdateAsync(int id, UpdateClientDto clientDto); //FirstOrDefault CAN BE NULL
        Task<Models.Client?> DeleteAsync(int id);
        Task<bool> ClientExists(int id);
    }
}