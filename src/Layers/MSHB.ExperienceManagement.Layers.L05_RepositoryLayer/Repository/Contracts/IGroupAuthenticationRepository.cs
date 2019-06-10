﻿using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts
{
    public interface IGroupAuthenticationRepository
    {
        Task<List<GroupAuth>> GetGroupAuthenticationAsync();
        Task<List<Role>> GetRolesAsync();
        Task<List<Role>> GetGroupRoleAsync();
    }
}
