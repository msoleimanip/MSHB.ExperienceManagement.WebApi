﻿using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Authority;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions
{
    public static class PresidentExtensions
    {
        public static bool IsAdmin(this User user)
        {
            return user.IsPresident!=null && user.IsPresident == (int)AuthorityKeys.Admin ? true : false;
        }
    }
}
