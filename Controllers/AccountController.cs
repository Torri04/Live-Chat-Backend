using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_API.Interfaces;
using ASP.NET_SignalR.Dtos;
using ASP.NET_SignalR.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SignalR.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService, UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] PostSignUpDto postRegisterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = _mapper.Map<AppUser>(postRegisterDto);
            var userResult = await _userManager.CreateAsync(appUser, postRegisterDto.Password);

            if (userResult.Succeeded)
            {
                return Ok("User has been created");
            }
            return StatusCode(500, userResult.Errors);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] PostSignInDto postSignInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userManager.Users.FirstOrDefault(x => x.UserName == postSignInDto.UserName.ToLower().Trim());

            if (user == null)
                return Unauthorized("Username is invalid");

            var result = await _signInManager.CheckPasswordSignInAsync(user, postSignInDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Password is incorrect");

            var token = _tokenService.CreateToken(user);

            return Ok(new { userId = user.Id, token = token });
        }
    }
}