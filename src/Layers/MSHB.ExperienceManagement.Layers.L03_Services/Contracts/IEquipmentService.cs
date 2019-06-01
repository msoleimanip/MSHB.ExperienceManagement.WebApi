using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IEquipmentService
    {
        Task<List<JsTreeNode>> GetEquipmentByUserAsync(User user);
        Task<long> AddEquipmentAsync(User user, AddEquipmentFormModel equipmentForm);
        Task<bool> EditEquipmentAsync(User user, EditEquipmentFormModel equipmentForm);
        Task<bool> DeleteEquipmentAsync(User user, List<long> equipmentIds);
    }
}
