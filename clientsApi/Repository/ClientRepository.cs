using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Data;
using clientsApi.Dto;
using clientsApi.Helpers;
using clientsApi.Interfaces;
using clientsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace clientsApi.Repository
{
    public class ClientRepository : IClientRepository
    {
        
        private readonly ApplicationDBContext _context;
        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> ClientExists(int id)
        {
            return _context.Clients.AnyAsync(c => c.Id == id);
        }

        public async Task<Client> CreateAsync(Client clientModel)
        {
            await _context.Clients.AddAsync(clientModel);
            await _context.SaveChangesAsync();
            return clientModel;
        }

        public async Task<Client?> DeleteAsync(int id)
        {
            var clientModel = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (clientModel == null)
            {
                return null;
            }
            _context.Clients.Remove(clientModel);
            await _context.SaveChangesAsync();
            return clientModel;
        }

        public async Task<List<Client>> GetAllAsync(QueryObject query)
        {
            var clients = _context.Clients.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                clients = clients.Where(c => c.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                clients = clients.Where(c => c.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    clients = query.IsDescending ? clients.OrderByDescending(c => c.Name) : clients.OrderBy(c => c.Name);
                }
                else if (query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
                { 
                    clients = query.IsDescending ? clients.OrderByDescending(c => c.CompanyName) : clients.OrderBy(c => c.CompanyName);
                }
            }

            var skip = (query.PageNumber - 1) * query.PageSize;


            return await clients.Skip(skip).Take(query.PageSize).ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.Include(c => c.Comments).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client?> UpdateAsync(int id, UpdateClientDto clientDto)
        {
            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (existingClient == null)
            {
                return null;
            }

            existingClient.Name = clientDto.Name;
            existingClient.CompanyName = clientDto.CompanyName;
            existingClient.PhoneNumber = clientDto.PhoneNumber;
            existingClient.Address = clientDto.Address;
            existingClient.Email = clientDto.Email;

            await _context.SaveChangesAsync();

            return existingClient;
        }
    }
}