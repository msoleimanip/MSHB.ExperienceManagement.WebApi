
using System.Collections.Generic;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Search
{
    public class ExperienceManagementSearchOptions
    {
        public ExperienceManagementSearchOptions()
        {
            this.UserRoles = new List<string>();
        }
        //public bool IncludeDetail { get; set; } = false;
        public bool IncludeSystemType { get; set; } = false;
        public bool IncludeCategory { get; set; } = false;
        public bool EnablePagination { get; set; } = true;
        public bool IncludeChilds { get; set; } = true;
        public bool IncludeProductParty { get; set; } = true;
        public bool IncludeProductLocationUpdates { get; set; } = false;
        public bool IncludeProductPartyLocations { get; set; } = false;
        public bool IncludeAttachmentFileFilter { get; set; } = false;
        public bool IncludeTranslationFilter { get; set; } = false;
        public List<string> UserRoles { get; set; }
        public int TopN { get; set; } = -1;
        public bool TimeLine { get; set; } = false;
    }
    public enum RedNumberPatternEnum
    {
        Equal,
        Contains,
        StartWith,
        EndWith,
    }
    public enum SearchTypeEnum
    {
        All,
        Me,
        Equal,
        Contains,
        StartWith,
        EndWith,
        GreaterThan,
        GreaterEqualThan,
        LessThan,
        LessEqualThan
    }
    public enum ConditionEnum
    {
        GreaterThan,
        GreaterEqualThan,
        LessThan,
        LessEqualThan
    }
    public enum DirectionEnum
    {
        SubjectIsStarter=1, // براساس این فیلد IsSubject فیلتر می گردد
        PartyIsStarter=0,
        Both=-1
    }
    public class TextSearch
    {
        public SearchTypeEnum Type { get; set; }
        public string Term { get; set; }
    }

    public class SortModel
    {
        public string ColId { get; set; }
        public string Sort { get; set; }
    }
}
