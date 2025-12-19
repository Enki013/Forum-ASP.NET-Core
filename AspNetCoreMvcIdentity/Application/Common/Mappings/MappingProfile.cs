using AutoMapper;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ReplyViewModels;

namespace AspNetCoreMvcIdentity.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostReply, PostReplyModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.AuthorRating, opt => opt.MapFrom(src => src.User.Rating))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.ReplyContent, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Post.Id));
                
            // İhtiyaç duyuldukça diğer haritalamalar eklenecek
        }
    }
}
