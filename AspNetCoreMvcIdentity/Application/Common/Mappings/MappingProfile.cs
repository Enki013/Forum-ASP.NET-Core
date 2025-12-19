using AutoMapper;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using AspNetCoreMvcIdentity.Models.ForumViewModels;
using AspNetCoreMvcIdentity.Models.PostViewModels;

namespace AspNetCoreMvcIdentity.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // PostReply -> PostReplyModel
            CreateMap<PostReply, PostReplyModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.User.Id.ToString()))
                .ForMember(dest => dest.AuthorImageUrl, opt => opt.MapFrom(src => src.User.GetProfileImageUrl()))
                .ForMember(dest => dest.AuthorRating, opt => opt.MapFrom(src => src.User.Rating))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.ReplyContent, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Post.Id))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.User.UserType));
                
            // Forum -> ForumListingModel
            CreateMap<Forum, ForumListingModel>()
                .ForMember(dest => dest.ForumImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
                
            // Post -> PostListingModel
            CreateMap<Post, PostListingModel>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.User.Id.ToString()))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.AuthorRating, opt => opt.MapFrom(src => src.User.Rating))
                .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => src.Created.ToString()));
        }
    }
}
