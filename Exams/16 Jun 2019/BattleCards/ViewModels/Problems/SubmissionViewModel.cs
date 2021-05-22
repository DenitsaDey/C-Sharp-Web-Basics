<<<<<<< Updated upstream
<<<<<<< HEAD
﻿namespace SulsApp.ViewModels.Problems
=======
﻿using System;

namespace SulsApp.ViewModels.Problems
>>>>>>> Stashed changes
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }
        public string SubmissionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AchievedResult { get; set; }
        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);

    }
=======
﻿using System;

namespace SulsApp.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }
        public string SubmissionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AchievedResult { get; set; }
        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);

    }
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
}