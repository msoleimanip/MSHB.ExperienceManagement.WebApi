using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03.Services.Security;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{

    public class UsersService : IUsersService
    {
        private readonly ExperienceManagementDbContext _uow;
        private readonly DbSet<User> _users;
        private readonly ISecurityService _securityService;

        public UsersService(ExperienceManagementDbContext uow, ISecurityService securityService)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _users = _uow.Set<User>();

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
        }

        public Task<long> AddUserAsync(User user, AddUserFormModel userForm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(User user, List<long> userIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(User user, List<Guid> userIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditUserAsync(User user, EditUserFormModel userForm)
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
        Task<Guid> IUsersService.AddUserAsync(User user, AddUserFormModel userForm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserLastActivityDateAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _uow.SaveChangesAsync();
        }


        public Task<User> FindUserAsync(Guid userId)
        {
            return _users.FindAsync(userId);
        }

        public Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return _users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<string> GetSerialNumberAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }


    }
}
