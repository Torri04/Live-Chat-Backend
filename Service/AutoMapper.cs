using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Model;
using AutoMapper;

namespace ASP.NET_SignalR.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, GetAppUserDto>().ForMember(x => x.UserId, opt => opt.MapFrom(y => y.Id));
            CreateMap<PostSignUpDto, AppUser>();

            CreateMap<ChatMessage, GetChatMessageDto>();
            CreateMap<PostChatMessageDto, ChatMessage>();

            CreateMap<ChatRoom, GetChatRoomDto>();
            CreateMap<PostChatRoomDto, ChatRoom>();

            CreateMap<UserChatRoom, GetUserChatRoomDto>();
            CreateMap<PostUserChatRoomDto, UserChatRoom>();
        }
    }
}