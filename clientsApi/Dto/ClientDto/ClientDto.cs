using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using clientsApi.Dto.CommentDto;

namespace clientsApi.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<CommentDto.CommentDto> Comments { get; set; } = new List<CommentDto.CommentDto>();
    }
}