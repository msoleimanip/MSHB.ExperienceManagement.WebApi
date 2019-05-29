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


namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Implement
{
    public class DbOrganizationRepository : IOrganizationRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbOrganizationRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }
        public async Task<List<Organization>> GetOrganizationByUserAsync(User user)
        {
            if (user.IsAdmin())
            {
                var organizations = await _uow.Organizations.ToListAsync();
                return organizations;
            }
            else
            {
                var organizations = await _uow.Organizations.Where(x => x.ParentId == 2).SelectMany(x => x.Children).ToListAsync();
                return organizations;
            }
        }
    }
}
