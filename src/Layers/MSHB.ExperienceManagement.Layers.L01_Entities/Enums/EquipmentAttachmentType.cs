using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Enums
{
    public enum EquipmentAttachmentType
    {
        [Display(Name = "اسناد")]
        Document = 1,

        [Display(Name = "ابزار")]
        Tool = 2,

        [Display(Name = "مکان")]
        Position = 3,

        [Display(Name = "کاتالوگ")]
        Catalog = 4,

        [Display(Name = "مواد")]
        Materials = 5,

        [Display(Name = "لوازم جانبی")]
        Accessory = 6
    }
}
