using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{

    public class UsersService : IUsersService
    {
   
        private readonly ISecurityService _securityService;

        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository,ISecurityService securityService)
        {
            _userRepository = userRepository;
            _userRepository.CheckArgumentIsNull(nameof(_userRepository));
            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
        }

        public Task<Guid> AddUserAsync(User user, AddUserFormModel userForm)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditUserAsync(User user, EditUserFormModel userForm)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUserAsync(User user, List<Guid> userIds)
        {
            throw new NotImplementedException();
        }
        public Task<UserViewModel> GetUserById(User user, Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<List<UserViewModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserLastActivityDateAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);

            await _userRepository.UpdateUserLastActivityDateAsync(user);
          
        }

        public async Task<User> FindUserAsync(Guid userId)
        {
            return await _userRepository.FindAsync(userId);           
        }

        public async Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return await _userRepository.FirstOrDefaultUserAsync(username, passwordHash);             
        }

        public async Task<string> GetSerialNumberAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

       
    }
}
