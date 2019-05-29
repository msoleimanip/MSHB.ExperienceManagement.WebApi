using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts
{
    public interface IOrganizationRepository
    {
        Task<List<Organization>> GetOrganizationByUserAsync(User user);
    }
}
