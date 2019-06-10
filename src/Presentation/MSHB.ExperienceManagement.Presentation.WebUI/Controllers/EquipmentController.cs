using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class EquipmentController : BaseController
    {
        private IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
            _equipmentService.CheckArgumentIsNull(nameof(_equipmentService));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _equipmentService.GetAsync(HttpContext.GetUser(), Id)));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> GetEquipmentByUser()
        {           
            var equipments = await _equipmentService.GetEquipmentByUserAsync(HttpContext.GetUser());
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> AddEquipment([FromBody] AddEquipmentFormModel equipmentForm)
        {            
            var equipments = await _equipmentService.AddEquipmentAsync(HttpContext.GetUser(), equipmentForm);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> EditEquipment([FromBody]  EditEquipmentFormModel equipmentForm)
        {
            var equipments = await _equipmentService.EditEquipmentAsync(HttpContext.GetUser(), equipmentForm);
            return Ok(GetRequestResult(equipments));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> DeleteEquipment([FromBody]
        [Required(ErrorMessage = "لیست تجهیزات ارسال شده برای حذف نامعتبر است")]List<long> equipmentIds)
        {
            var equipments = await _equipmentService.DeleteEquipmentAsync(HttpContext.GetUser(), equipmentIds);
            return Ok(GetRequestResult(equipments));
        }
    }
}