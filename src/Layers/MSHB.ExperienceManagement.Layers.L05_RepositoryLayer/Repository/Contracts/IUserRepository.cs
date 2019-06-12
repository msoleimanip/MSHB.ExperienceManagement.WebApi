using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts
{
    public interface IUserRepository
    {
        Task UpdateUserLastActivityDateAsync(User user);
        Task<User> FindAsync(Guid userId);
        Task<User> FirstOrDefaultUserAsync(string username, string passwordHash);
    }
}
