using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class SearchIssueDetailsViewModel
    {
        public IssueViewModel IssueViewModel { get; set; }
        public List<IssueDetailViewModel> issueDetailViewModel { get; set; }
    }
}
