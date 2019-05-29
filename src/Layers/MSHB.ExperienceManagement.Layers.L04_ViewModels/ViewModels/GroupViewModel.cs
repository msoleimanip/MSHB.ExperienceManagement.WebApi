using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class GroupViewModel
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsDefault { get; set; }
    }
}
