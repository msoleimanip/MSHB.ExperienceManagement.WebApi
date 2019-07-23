using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IEquipmentService
    {
        Task<EquipmentViewModel> GetAsync(User user, long Id);
        Task<List<JsTreeNode>> GetEquipmentByUserAsync(User user);
        Task<long> AddEquipmentAsync(User user, AddEquipmentFormModel equipmentForm);
        Task<bool> EditEquipmentAsync(User user, EditEquipmentFormModel equipmentForm);
        Task<bool> DeleteEquipmentAsync(User user, List<long> equipmentIds);
        Task<List<JsTreeNode>> GetUserEquipmentForUserAsync(User user, Guid userId);
        Task<bool> AddEquipmentAttachmentAsync(User user, AddEquipmentAttachmentFormModel equipmentAttachmentForm);
        Task<bool> EditEquipmentAttachmentAsync(User user, EditEquipmentAttachmentFormModel equipmentAttachmentForm);
        Task<EquipmentAttachmentViewModel> GetEquipmentAttachmentAsync(User user, long id);
        Task<List<EquipmentAttachmentViewModel>> GetEquipmentAttachmentForUserAsync(User user);
        Task<List<EquipmentAttachmentViewModel>> GetEquipmentAttachmentByEquipmentIdAsync(User user, long id);
    }
}
