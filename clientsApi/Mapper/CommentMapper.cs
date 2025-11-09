using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Dto.CommentDto;
using clientsApi.Models;

namespace clientsApi.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                ClientId = comment.ClientId

            };
        }
        public static Comment ToComment(this CreateCommentDto createCommentDto, int clientId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                ClientId = clientId
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentDto updateCommentDto)
        {
            return new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
            };
        }
    }
}
