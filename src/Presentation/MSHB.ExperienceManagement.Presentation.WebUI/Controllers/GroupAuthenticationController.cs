using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupAuthenticationController : BaseController
    {
        private readonly IGroupAuthenticationService _groupAuthenticationService;

        public GroupAuthenticationController(
            IGroupAuthenticationService groupAuthenticationService
            )
        {
            _groupAuthenticationService = groupAuthenticationService;
            _groupAuthenticationService.CheckArgumentIsNull(nameof(_groupAuthenticationService));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> GetGroupAuthentication()
        {
            return Ok(GetRequestResult(await _groupAuthenticationService.GetGroupAuthenticationAsync()));
          
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetGroupRole([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _groupAuthenticationService.GetGroupRoleAsync(HttpContext.GetUser(), Id)));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> AddGroup([FromBody] AddGroupFormModel groupForm)
        {
            var group = await _groupAuthenticationService.AddGroupAsync(HttpContext.GetUser(), groupForm);
            return Ok(GetRequestResult(group));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> EditGroup([FromBody]  EditGroupFormModel groupForm)
        {
            var group = await _groupAuthenticationService.EditGroupAsync(HttpContext.GetUser(), groupForm);
            return Ok(GetRequestResult(group));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> DeleteGroup([FromBody]
        [Required(ErrorMessage = "لیست گروه های ارسال شده برای حذف نامعتبر است")]List<long> groupIds)
        {
            var groups = await _groupAuthenticationService.DeleteGroupAsync(HttpContext.GetUser(), groupIds);
            return Ok(GetRequestResult(groups));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(GetRequestResult(await _groupAuthenticationService.GetRolesAsync(HttpContext.GetUser())));
        }
    }
}