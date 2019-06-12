﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class UsersServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage AddUserError =
           new ExperienceManagementErrorMessage("AUE-1000", "خطا در افزودن کاربر اتفاق افتاده است");
        public static readonly ExperienceManagementErrorMessage GroupNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1001", "گروه ای که انتخاب کرده اید وجود ندارد ");
        public static readonly ExperienceManagementErrorMessage OrganizationNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1002", "رده ای که انتخاب کرده اید وجود ندارد ");
        public static readonly ExperienceManagementErrorMessage UserExistError =
           new ExperienceManagementErrorMessage("AUE-1003", "کاربری با این نام در سیستم وجود دارد امکان اضافه کردن وجود ندارد.");

        

    }

}