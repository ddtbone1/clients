using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Dto;
using clientsApi.Models;
using clientsApi.Dto.CommentDto;    

namespace clientsApi.Mapper
{
    public static class ClientMapper
    {
        public static ClientDto ToClientDto(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                CompanyName = client.CompanyName,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                Email = client.Email,
                Comments = client.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }
        public static Client ToClient(this CreateClientDto createClientDto)
        {
            return new Client
            {
                Name = createClientDto.Name,
                CompanyName = createClientDto.CompanyName,
                PhoneNumber = createClientDto.PhoneNumber,
                Address = createClientDto.Address,
                Email = createClientDto.Email
            };
        }
    }
}