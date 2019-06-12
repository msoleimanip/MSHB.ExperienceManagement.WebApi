using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Implement
{   
    public class DbUserRepository:IUserRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbUserRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }

        public Task<User> FindAsync(Guid userId)
        {
            return _uow.Users.FindAsync(userId);
        }

        public Task<User> FirstOrDefaultUserAsync(string username, string passwordHash)
        {
            return _uow.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task UpdateUserLastActivityDateAsync(User user)
        {
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
    }
}
