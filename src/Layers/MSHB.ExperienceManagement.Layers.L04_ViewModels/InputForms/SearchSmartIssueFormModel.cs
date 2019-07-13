using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class SearchSmartIssueFormModel
    {
        public string SearchContent { get; set; }
        public Guid? UserId { get; set; }
        public List<long> EquipmentIds { get; set; }
        public FilterType? FilterType { get; set; }
        public SortType? SortType { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 15;
    }
    public enum FilterType
    {
        NoAnswers = 1,
        NoAcceptedAnswer = 2,
        AcceptedAnswer = 3
    }

    public enum SortType
    {
        Newest = 1,
        RecentActivity = 2,
        MostLikes = 3,

    }
}
