using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issue
{
    public class CarIssuesViewModel
    {
        public string CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public virtual ICollection<IssueViewModel> Issues { get; set; } = new HashSet<IssueViewModel>();
    }
}
