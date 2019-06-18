﻿
using System.Collections.Generic;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Search
{
    public class SearchModel
    {
        public SortModel SortModel { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class SortModel
    {
        public string Col { get; set; }
        public string Sort { get; set; }
    }
}
