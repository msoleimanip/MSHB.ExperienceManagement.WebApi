using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using System.Linq;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
  
    public class GroupAuthenticationService : IGroupAuthenticationService
    {
        private readonly IGroupAuthenticationRepository _groupAuthenticationRepository;


        public GroupAuthenticationService(IGroupAuthenticationRepository groupAuthenticationRepository)
        {
            _groupAuthenticationRepository = groupAuthenticationRepository;
            _groupAuthenticationRepository.CheckArgumentIsNull(nameof(_groupAuthenticationRepository));
        }

        public async Task<List<GroupAuthenticationViewModel>> GetGroupAuthenticationAsync()
        {
            var groupAuthentications = await _groupAuthenticationRepository.GetGroupAuthenticationAsync();
            return groupAuthentications.Select(x => new GroupAuthenticationViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }
    }
}
