using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IGroupAuthenticationService
    {
        Task<List<GroupAuthenticationViewModel>> GetGroupAuthenticationAsync();
        Task<List<RoleViewModel>> GetGroupRoleAsync(User user, long Id);
        Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm);
        Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm);
        Task<bool> DeleteGroupAsync(User user, List<long> groupIds);

    }
}
