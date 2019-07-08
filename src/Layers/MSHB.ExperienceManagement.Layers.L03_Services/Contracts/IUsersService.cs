using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IUsersService
    {
        Task<string> GetSerialNumberAsync(Guid userId);
        Task<User> FindUserAsync(string username, string password);
        Task<User> FindUserLoginAsync(string username, string password);
        Task<User> FindUserAsync(Guid userId);
        Task UpdateUserLastActivityDateAsync(Guid userId);
        Task<Guid> AddUserAsync(User user, AddUserFormModel userForm);
        Task<bool> EditUserAsync(User user, EditUserFormModel userForm);      
        Task<SearchUserViewModel> GetUsersAsync(SearchUserFormModel searchUserForm);
        Task<UserViewModel> GetUserById(User user, Guid id);
        Task<bool> UserOrganizationAssignAsync(User user, UserOrgAssignFormModel userOrgAssignForm);
        Task<bool> UserEquipmentAssignAsync(User user, UserEquipmentAssignFormModel userEquipmentAssignForm);
        Task<bool> ChangeActivateUserAsync(User user, ChangeActivationFormModel userForm);
        Task<bool> ChangePasswordAsync(User user, ChangePasswordFormModel userForm);
    }
}
