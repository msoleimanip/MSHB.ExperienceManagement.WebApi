using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using Newtonsoft.Json.Linq;


namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class AccountController : BaseController
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;


        public AccountController(
            IUsersService usersService,
            ITokenStoreService tokenStoreService
            )
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(_tokenStoreService));

        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]  LoginViewModels loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("user is not set.");
            } 
            var user = await _usersService.FindUserAsync(loginUser.UserName, loginUser.Password);
            if (user == null || !user.IsActive)
            {
                return Unauthorized();
            }

            var (accessToken, refreshToken) = await _tokenStoreService.CreateJwtTokens(user, refreshTokenSource: null);
            return Ok(GetRequestResult(new { access_token = accessToken, refresh_token = refreshToken }));
        }
       
        [AllowAnonymous]
       
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody]JToken jsonBody)
        {
            var refreshToken = jsonBody.Value<string>("refreshToken");
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return BadRequest("refreshToken is not set.");
            }

            var token = await _tokenStoreService.FindTokenAsync(refreshToken);
            if (token == null)
            {
                return Unauthorized();
            }

            var (accessToken, newRefreshToken) = await _tokenStoreService.CreateJwtTokens(token.User, refreshToken);
            return Ok(GetRequestResult(new { access_token = accessToken, refresh_token = newRefreshToken }));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout([FromBody]string refreshToken)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

            // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            await _tokenStoreService.RevokeUserBearerTokensAsync(userIdValue, refreshToken);
          

            return Ok(GetRequestResult(true));
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        
        public async Task<IActionResult> AddUser([FromBody] AddUserFormModel userForm)
        {
            var user = await _usersService.AddUserAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(user));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> EditUser([FromBody]  EditUserFormModel userForm)
        {
            var user = await _usersService.EditUserAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(user));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> DeleteUser([FromBody]
        [Required(ErrorMessage = "لیست کاربران ارسال شده برای حذف نامعتبر است")] List<Guid> userIds)
        {
            var users = await _usersService.DeleteUserAsync(HttpContext.GetUser(), userIds);
            return Ok(GetRequestResult(users));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(GetRequestResult(await _usersService.GetUsersAsync()));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserById([FromQuery] Guid Id)
        {
            return Ok(GetRequestResult(await _usersService.GetUserById(HttpContext.GetUser(), Id)));
        }

    }

    
}