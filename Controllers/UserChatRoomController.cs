using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Extension;
using ASP.NET_SignalR.Interface;
using ASP.NET_SignalR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SignalR.Controllers
{
    [Route("api/userchatroom")]
    [ApiController]
    public class UserChatRoomController : ControllerBase
    {
        private readonly IUserChatRoomRepository _userChatRoomRepository;
        private readonly IMapper _mapper;

        public UserChatRoomController(IUserChatRoomRepository userChatRoomRepository, IMapper mapper)
        {
            _userChatRoomRepository = userChatRoomRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetChatRooms([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userChatRooms = await _userChatRoomRepository.GetAllChatRooms(id.ToString());

            if (userChatRooms == null)
                return NotFound();

            var userChatRoomsDto = _mapper.Map<List<GetUserChatRoomDto>>(userChatRooms);
            return Ok(userChatRoomsDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUserChatRoom([FromBody] PostUserChatRoomDto postUserChatRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userChatRoom = _mapper.Map<UserChatRoom>(postUserChatRoomDto);

            var userId = User.GetUserId();
            userChatRoom.UserId = userId;

            userChatRoom = await _userChatRoomRepository.PostUserChatRoom(userChatRoom);

            var userChatRoomDto = _mapper.Map<GetUserChatRoomDto>(userChatRoom);

            return Ok(userChatRoomDto);
        }
    }
}
