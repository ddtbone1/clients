using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clientsApi.Dto.CommentDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public int? ClientId { get; set; }
    }
}