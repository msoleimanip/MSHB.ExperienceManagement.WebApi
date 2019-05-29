using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
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
        Task<User> FindUserAsync(Guid userId);
        Task UpdateUserLastActivityDateAsync(Guid userId);
    }
}
