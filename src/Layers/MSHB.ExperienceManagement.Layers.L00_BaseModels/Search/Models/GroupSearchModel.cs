using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Search.Models
{ 
    public class GroupSearchModel
    {
        public long? GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
