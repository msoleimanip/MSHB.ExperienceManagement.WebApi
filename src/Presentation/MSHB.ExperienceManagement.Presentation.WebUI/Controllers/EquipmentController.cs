using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Presentation.WebUI.filters;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Equipment")]
    public class EquipmentController : BaseController
    {
        private IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
            _equipmentService.CheckArgumentIsNull(nameof(_equipmentService));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Equipment-Get")]
        public async Task<IActionResult> Get([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _equipmentService.GetAsync(HttpContext.GetUser(), Id)));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-GetEquipmentByUser")]
        public async Task<IActionResult> GetEquipmentByUser()
        {           
            var equipments = await _equipmentService.GetEquipmentByUserAsync(HttpContext.GetUser());
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-GetUserEquipmentForUser")]
        [ValidateModelAttribute]

        public async Task<IActionResult> GetUserEquipmentForUser([FromQuery] Guid userId)
        {
            var equipments = await _equipmentService.GetUserEquipmentForUserAsync(HttpContext.GetUser(), userId);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-AddEquipment")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddEquipment([FromBody] AddEquipmentFormModel equipmentForm)
        {            
            var equipments = await _equipmentService.AddEquipmentAsync(HttpContext.GetUser(), equipmentForm);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-EditEquipment")]
        [ValidateModelAttribute]
        public async Task<IActionResult> EditEquipment([FromBody]  EditEquipmentFormModel equipmentForm)
        {
            var equipments = await _equipmentService.EditEquipmentAsync(HttpContext.GetUser(), equipmentForm);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-DeleteEquipment")]
        [ValidateModelAttribute]
        public async Task<IActionResult> DeleteEquipment([FromBody]
        [Required(ErrorMessage = "لیست تجهیزات ارسال شده برای حذف نامعتبر است")]List<long> equipmentIds)
        {
            var equipments = await _equipmentService.DeleteEquipmentAsync(HttpContext.GetUser(), equipmentIds);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-AddEquipmentAttachment")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddEquipmentAttachment([FromBody] AddEquipmentAttachmentFormModel equipmentAttachmentForm)
        {
            var equipments = await _equipmentService.AddEquipmentAttachmentAsync(HttpContext.GetUser(), equipmentAttachmentForm);
            return Ok(GetRequestResult(equipments));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-EditEquipmentAttachment")]
        [ValidateModelAttribute]
        public async Task<IActionResult> EditEquipmentAttachment([FromBody] EditEquipmentAttachmentFormModel equipmentAttachmentForm)
        {
            var equipments = await _equipmentService.EditEquipmentAttachmentAsync(HttpContext.GetUser(), equipmentAttachmentForm);
            return Ok(GetRequestResult(equipments));
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "Equipment-GetEquipmentAttachment")]
        public async Task<IActionResult> GetEquipmentAttachment([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _equipmentService.GetEquipmentAttachmentAsync(HttpContext.GetUser(), Id)));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Equipment-GetEquipmentAttachmentForUser")]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetEquipmentAttachmentForUser()
        {
            var equipmentAtts = await _equipmentService.GetEquipmentAttachmentForUserAsync(HttpContext.GetUser());
            return Ok(GetRequestResult(equipmentAtts));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Equipment-GetEquipmentAttachmentByEquipmentId")]
        public async Task<IActionResult> GetEquipmentAttachmentByEquipmentId([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _equipmentService.GetEquipmentAttachmentByEquipmentIdAsync(HttpContext.GetUser(), Id)));
        }
    }
}