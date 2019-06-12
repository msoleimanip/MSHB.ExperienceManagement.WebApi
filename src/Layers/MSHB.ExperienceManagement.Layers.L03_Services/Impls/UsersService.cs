using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{

    public class UsersService : IUsersService
    {
        private readonly ISecurityService _securityService;

        private readonly ExperienceManagementDbContext _context;
        public UsersService(ISecurityService securityService, ExperienceManagementDbContext context)
        {
            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public async Task<Guid> AddUserAsync(User user, AddUserFormModel userForm)
        {
            try
            {
                if (_context.Users.Any(c => c.Username.ToLower() == userForm.Username.ToLower()))
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.UserExistError);
                }
                var groupRole = await _context.GroupAuthRoles.Where(c => c.GroupAuthId == userForm.GroupAuthId).ToListAsync();
                if (groupRole == null)
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.GroupNotFoundError);
                }
                var org = await _context.Organizations.FirstOrDefaultAsync(c => c.Id == userForm.OrganizationId);
                if (org == null)
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.OrganizationNotFoundError);
                }
                var userReg = new User()
                {
                    OrganizationId = org.Id,
                    GroupAuthId = userForm.GroupAuthId,
                    FirstName = userForm.FirstName,
                    Description = userForm.Description,
                    IsActive = userForm.IsActive,
                    IsPresident = userForm.IsPresident,
                    LastName = userForm.LastName,
                    Password = _securityService.GetSha256Hash(userForm.Password),
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    Location = userForm.Location,
                    PhoneNumber = userForm.PhoneNumber,
                    Username = userForm.Username.ToLower()
                };
                _context.Users.Add(userReg);
                _context.UserRoles.AddRange(groupRole.Select(c => c.RoleId).ToList().Select(roleId =>
                                                      new UserRole
                                                      {
                                                          User = userReg,
                                                          RoleId = roleId
                                                      }));
                _context.SaveChanges();
                return userReg.Id;

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(UsersServiceErrors.AddUserError, ex);
            }
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
            await _context.SaveChangesAsync();


        }
        public async Task<User> FindUserAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<string> GetSerialNumberAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }


    }
}
