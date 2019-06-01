﻿using System;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Http;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Authority;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using SubPro.WebUI.Shared.Common.IdentityToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebCore
{
    public static class ControllerUtils
    {
        public static List<string> GetUserRoleNames(this HttpContext context)
        {
            try
            {
                var res = context.User.Identity.GetUserClaimRoles();

                if (res.Count>0)
                {
                    return (List<string>)res;
                }

                throw new ExperienceManagementGlobalException(ControllerUtilsErrors.UserRolesNotFound);
            }          
            catch (Exception e)
            {
                throw new ExperienceManagementGlobalException(ControllerUtilsErrors.GetUserRoles, e);
            }
        }
        public static User GetUser(this HttpContext context)
        {
            try
            {
                User user = new User
                {
                    Username = context.User.Identity.GetUserName(),
                    FirstName = context.User.Identity.GetUserFirstName(),
                    LastName = context.User.Identity.GetUserLastName(),
                    Id = Guid.Parse(context.User.Identity.GetUserId<string>()),  
                    IsPresident=context.User.Identity.GetUserPresident<int>()
                };

                return user;
            }
         
            catch (Exception e)
            {
                throw new ExperienceManagementGlobalException(ControllerUtilsErrors.GetUserError, e);
            }
        }

        public static AuthorityKeys GetUserPresident(this HttpContext context)
        {
            try
            {
                var IsPresident = (AuthorityKeys)context.User.Identity.GetUserPresident<int>();
                return IsPresident;
            }

            catch (Exception e)
            {
                throw new ExperienceManagementGlobalException(ControllerUtilsErrors.GetUserPresidentError, e);
            }
        }

        public static TimeSpan? ConvertTimeStringToMiliseconds(string time)
        {
            if (string.IsNullOrEmpty(time)) return null;
            var parts = time.Split(":").Select(x => int.Parse(x)).ToList();
            var hours = TimeSpan.FromHours(parts[0]).TotalMilliseconds;
            var minutes = TimeSpan.FromMinutes(parts[1]).TotalMilliseconds;
            var seconds = TimeSpan.FromSeconds(parts[2]).TotalMilliseconds;
            var totalMiliseconds = hours + minutes + seconds;
            return TimeSpan.FromMilliseconds(totalMiliseconds);


        }
  

     }
}