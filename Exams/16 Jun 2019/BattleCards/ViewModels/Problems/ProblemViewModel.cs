using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SubmissionViewModel> Submissions { get; set; }

    }
}
