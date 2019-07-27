﻿using System;
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
using MSHB.ExperienceManagement.Presentation.WebUI.filters;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using Newtonsoft.Json.Linq;


namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Account")]
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
        [ValidateModelAttribute]
        public async Task<IActionResult> Login([FromBody]  LoginViewModels loginUser)
        {
            var user = await _usersService.FindUserLoginAsync(loginUser.UserName, loginUser.Password);


            var (accessToken, refreshToken) = await _tokenStoreService.CreateJwtTokens(user, refreshTokenSource: null);
            return Ok(GetRequestResult(new { access_token = accessToken, refresh_token = refreshToken }));
        }

        [Authorize(Roles = "Account-RefreshToken")]

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody]JToken jsonBody)
        {
            var refreshToken = jsonBody.Value<string>("refreshToken");
            var token = await _tokenStoreService.FindTokenLoginAsync(refreshToken);
            var (accessToken, newRefreshToken) = await _tokenStoreService.CreateJwtTokens(token.User, refreshToken);
            return Ok(GetRequestResult(new { access_token = accessToken, refresh_token = newRefreshToken }));
        }

        [AllowAnonymous]
        [ValidateModelAttribute]
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
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-AddUser")]

        public async Task<IActionResult> AddUser([FromBody] AddUserFormModel userForm)
        {
            var user = await _usersService.AddUserAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(user));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-EditUser")]
        public async Task<IActionResult> EditUser([FromBody]  EditUserFormModel userForm)
        {
            var user = await _usersService.EditUserAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(user));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-ChangeActivateUser")]
        public async Task<IActionResult> ChangeActivateUser([FromBody]
                                                                ChangeActivationFormModel userForm)
        {
            var users = await _usersService.ChangeActivateUserAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(users));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]
                                                                ChangePasswordFormModel userForm)
        {
            var users = await _usersService.ChangePasswordAsync(HttpContext.GetUser(), userForm);
            return Ok(GetRequestResult(users));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-GetUsers")]
        public async Task<IActionResult> GetUsers([FromBody] SearchUserFormModel searchUserForm)
        {
            return Ok(GetRequestResult(await _usersService.GetUsersAsync(searchUserForm)));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-UserOrganizationAssign")]
        public async Task<IActionResult> UserOrganizationAssign([FromBody]  UserOrgAssignFormModel userOrgAssignForm)
        {
            var userorgAssign = await _usersService.UserOrganizationAssignAsync(HttpContext.GetUser(), userOrgAssignForm);
            return Ok(GetRequestResult(userorgAssign));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-UserEquipmentAssign")]
        public async Task<IActionResult> UserEquipmentAssign([FromBody]  UserEquipmentAssignFormModel userEquipmentAssignForm)
        {
            var userEquipmentAssign = await _usersService.UserEquipmentAssignAsync(HttpContext.GetUser(), userEquipmentAssignForm);
            return Ok(GetRequestResult(userEquipmentAssign));
        }

        [HttpGet("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] Guid Id)
        {
            return Ok(GetRequestResult(await _usersService.GetUserById(HttpContext.GetUser(), Id)));
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        [Authorize(Roles = "Account-GetOrganizationUsers")]
        public async Task<IActionResult> GetOrganizationUsers([FromQuery] long orgId)
        {
            var userEquipmentAssign = await _usersService.GetOrganizationUsersAsync(HttpContext.GetUser(), orgId);
            return Ok(GetRequestResult(userEquipmentAssign));
        }



    }

    
}