using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Interface;
using ASP.NET_SignalR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SignalR.Controllers
{
    [Route("api/chatroom")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IMapper _mapper;

        public ChatRoomController(IChatRoomRepository chatRoomRepository, IMapper mapper)
        {
            _chatRoomRepository = chatRoomRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostChatRoom([FromBody] PostChatRoomDto postChatRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var chatRoom = _mapper.Map<ChatRoom>(postChatRoomDto);

            chatRoom = await _chatRoomRepository.PostChatRoom(chatRoom);

            var chatRoomDto = _mapper.Map<GetChatRoomDto>(chatRoom);

            return Ok(chatRoomDto);
        }
    }
}
