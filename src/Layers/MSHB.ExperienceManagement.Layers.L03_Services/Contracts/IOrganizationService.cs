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
    public interface IOrganizationService
    {
        Task<OrganizationViewModel> GetAsync(User user,long Id);
        Task<List<JsTreeNode>> GetOrganizationByUserAsync(User user);
        Task<List<JsTreeNode>> GetUserOrgazinationForUserAsync(User user, Guid userId);
        Task<long> AddOrganizationAsync(User user, AddOrgFormModel orgForm);
        Task<bool> EditOrganizationAsync(User user, EditOrgFormModel orgForm);
        Task<bool> DeleteOrganizationAsync(User user, List<long> orgIds);
    }
}
