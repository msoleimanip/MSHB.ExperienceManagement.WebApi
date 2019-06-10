using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class OrganizationViewModel
    {
        public long Id { get; set; }
        public string OrganizationName { get; set; }

        public string Description { get; set; }

        public long? ParentId { get; set; }
    }
}
