using MSHB.ExperienceManagement.Layers.L00_BaseModels.Search.Models;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts
{
    public interface IGroupAuthenticationRepository
    {
        Task<List<GroupAuth>> GetGroupAuthenticationAsync();
        Task<List<GroupAuth>> SearchGroupAsync(GroupSearchModel groupmodel);
        Task<List<Role>> GetRolesAsync();
        Task<List<Role>> GetGroupRoleAsync(long id);        
        Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm);
        Task<bool> DeleteGroupAsync(User user, List<long> groupIds);
        Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm);
    }
}
