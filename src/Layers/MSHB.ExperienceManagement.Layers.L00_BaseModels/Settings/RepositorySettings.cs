using System;
using Microsoft.AspNetCore.Identity;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Settings
{
    public class RepositorySettings
    {
    
        public Connectionstrings ConnectionStrings { get; set; }
        public ActiveDatabase ActiveDatabase { get; set; }
    }
}