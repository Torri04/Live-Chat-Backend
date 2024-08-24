using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Extension;
using ASP.NET_SignalR.Interface;
using ASP.NET_SignalR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SignalR.Controllers
{
    [Route("api/chatmessage")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IMapper _mapper;

        public ChatMessageController(IChatMessageRepository chatMessageRepository, IMapper mapper)
        {
            _chatMessageRepository = chatMessageRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetAllChatMessages([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var chatMessages = await _chatMessageRepository.GetChatMessagesByChatRoomId(id);

            if (chatMessages == null)
                return NotFound();

            var chatMessagesDto = _mapper.Map<List<GetChatMessageDto>>(chatMessages);

            return Ok(chatMessagesDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostChatMessage([FromBody] PostChatMessageDto postChatMessageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var chatMessages = _mapper.Map<ChatMessage>(postChatMessageDto);

            var userId = User.GetUserId();
            chatMessages.UserId = userId;

            chatMessages = await _chatMessageRepository.PostChatMessage(chatMessages);

            var chatMessagesDto = _mapper.Map<GetChatMessageDto>(chatMessages);

            return Ok(chatMessagesDto);
        }
    }
}
